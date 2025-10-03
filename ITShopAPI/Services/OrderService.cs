using Microsoft.EntityFrameworkCore;
using ITShopAPI.Data;
using ITShopAPI.DTOs;
using ITShopAPI.Models;
using ITShopAPI.Repositories;

namespace ITShopAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly ApplicationDbContext _context;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<Product> productRepository,
            IRepository<Customer> customerRepository,
            ApplicationDbContext context)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
            // Validate customer exists
            var customer = await _customerRepository.GetByIdAsync(orderDto.CustomerId);
            if (customer == null)
                throw new ArgumentException("Customer not found");

            // Validate stock availability for all items
            foreach (var item in orderDto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new ArgumentException($"Product with ID {item.ProductId} not found");

                if (product.Stock < item.Quantity)
                    throw new InvalidOperationException($"Insufficient stock for product {product.Name}. Available: {product.Stock}, Requested: {item.Quantity}");
            }

            // Create order - Stock will be reduced when payment is confirmed
            var order = new Order
            {
                CustomerId = orderDto.CustomerId,
                OrderDate = DateTime.Now,
                Status = "Pending",
                PaymentStatus = "Pending",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                OrderItems = new List<OrderItem>()
            };

            decimal totalAmount = 0;

            foreach (var itemDto in orderDto.Items)
            {
                var product = await _productRepository.GetByIdAsync(itemDto.ProductId);
                var subTotal = product.Price * itemDto.Quantity;

                var orderItem = new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    UnitPrice = product.Price,
                    SubTotal = subTotal
                };

                order.OrderItems.Add(orderItem);
                totalAmount += subTotal;
            }

            order.TotalAmount = totalAmount;

            var createdOrder = await _orderRepository.AddAsync(order);

            var result = await GetOrderByIdAsync(createdOrder.Id);
            return result ?? throw new InvalidOperationException("Failed to retrieve created order");
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return null;

            return new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name ?? string.Empty,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                PaymentStatus = order.PaymentStatus,
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product?.Name ?? string.Empty,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    SubTotal = oi.SubTotal
                }).ToList()
            };
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId)
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();

            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer?.Name ?? string.Empty,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status,
                PaymentStatus = order.PaymentStatus,
                Items = order.OrderItems.Select(oi => new OrderItemDto
                {
                    Id = oi.Id,
                    ProductId = oi.ProductId,
                    ProductName = oi.Product?.Name ?? string.Empty,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    SubTotal = oi.SubTotal
                }).ToList()
            });
        }

        public async Task<OrderDto> ConfirmPaymentAsync(int orderId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .FirstOrDefaultAsync(o => o.Id == orderId);

                if (order == null)
                    throw new ArgumentException("Order not found");

                if (order.PaymentStatus == "Paid")
                    throw new InvalidOperationException("Payment already confirmed");

                // Reduce stock for each item when payment is confirmed
                foreach (var item in order.OrderItems)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);

                    if (product.Stock < item.Quantity)
                        throw new InvalidOperationException($"Insufficient stock for product {product.Name}");

                    product.Stock -= item.Quantity;
                    product.UpdatedDate = DateTime.Now;
                    await _productRepository.UpdateAsync(product);
                }

                // Update order status
                order.PaymentStatus = "Paid";
                order.Status = "Confirmed";
                order.UpdatedDate = DateTime.Now;
                await _orderRepository.UpdateAsync(order);

                await transaction.CommitAsync();

                var result = await GetOrderByIdAsync(orderId);
                return result ?? throw new InvalidOperationException("Failed to retrieve updated order");
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null) return false;

            if (order.PaymentStatus == "Paid")
                throw new InvalidOperationException("Cannot cancel a paid order");

            order.Status = "Cancelled";
            order.UpdatedDate = DateTime.Now;
            await _orderRepository.UpdateAsync(order);

            return true;
        }
    }
}
