using Xunit;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ITShopAPI.Services;
using ITShopAPI.Repositories;
using ITShopAPI.Models;
using ITShopAPI.DTOs;
using ITShopAPI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace ITShopAPI.Tests.Services
{
    public class OrderServiceTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly Repository<Order> _orderRepository;
        private readonly Repository<Product> _productRepository;
        private readonly Repository<Customer> _customerRepository;
        private readonly OrderService _service;

        public OrderServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            _context = new ApplicationDbContext(options);
            _orderRepository = new Repository<Order>(_context);
            _productRepository = new Repository<Product>(_context);
            _customerRepository = new Repository<Customer>(_context);
            _service = new OrderService(_orderRepository, _productRepository, _customerRepository, _context);

            SeedTestData();
        }

        private void SeedTestData()
        {
            var customer = new Customer
            {
                Id = 1,
                Name = "Test Customer",
                Email = "test@test.com",
                Phone = "1234567890",
                Address = "Test Address"
            };

            var product1 = new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description 1",
                Price = 100,
                Stock = 10,
                ImageUrl = "test1.jpg"
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Description 2",
                Price = 200,
                Stock = 5,
                ImageUrl = "test2.jpg"
            };

            _context.Customers.Add(customer);
            _context.Products.AddRange(product1, product2);
            _context.SaveChanges();
        }

        [Fact]
        public async Task CreateOrderAsync_WithValidData_ShouldCreateOrder()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 2 },
                    new CreateOrderItemDto { ProductId = 2, Quantity = 1 }
                }
            };

            var result = await _service.CreateOrderAsync(orderDto);

            result.Should().NotBeNull();
            result.CustomerId.Should().Be(1);
            result.TotalAmount.Should().Be(400);
            result.Status.Should().Be("Pending");
            result.PaymentStatus.Should().Be("Pending");
            result.Items.Should().HaveCount(2);
        }

        [Fact]
        public async Task CreateOrderAsync_WithInvalidCustomer_ShouldThrowException()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 999,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            };

            await Assert.ThrowsAsync<ArgumentException>(
                async () => await _service.CreateOrderAsync(orderDto)
            );
        }

        [Fact]
        public async Task CreateOrderAsync_WithInsufficientStock_ShouldThrowException()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 100 }
                }
            };

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _service.CreateOrderAsync(orderDto)
            );
            exception.Message.Should().Contain("Insufficient stock");
        }

        [Fact]
        public async Task GetOrderByIdAsync_WhenOrderExists_ShouldReturnOrder()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            };
            var createdOrder = await _service.CreateOrderAsync(orderDto);

            var result = await _service.GetOrderByIdAsync(createdOrder.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(createdOrder.Id);
            result.CustomerId.Should().Be(1);
        }

        [Fact]
        public async Task GetOrderByIdAsync_WhenOrderNotExists_ShouldReturnNull()
        {
            var result = await _service.GetOrderByIdAsync(999);

            result.Should().BeNull();
        }

        [Fact]
        public async Task ConfirmPaymentAsync_WithValidOrder_ShouldReduceStockAndUpdateStatus()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 2 }
                }
            };
            var createdOrder = await _service.CreateOrderAsync(orderDto);
            var originalStock = (await _productRepository.GetByIdAsync(1)).Stock;

            var result = await _service.ConfirmPaymentAsync(createdOrder.Id);

            result.Should().NotBeNull();
            result.PaymentStatus.Should().Be("Paid");
            result.Status.Should().Be("Confirmed");

            var updatedProduct = await _productRepository.GetByIdAsync(1);
            updatedProduct.Stock.Should().Be(originalStock - 2);
        }

        [Fact]
        public async Task ConfirmPaymentAsync_WhenAlreadyPaid_ShouldThrowException()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            };
            var createdOrder = await _service.CreateOrderAsync(orderDto);
            await _service.ConfirmPaymentAsync(createdOrder.Id);

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _service.ConfirmPaymentAsync(createdOrder.Id)
            );
            exception.Message.Should().Contain("Payment already confirmed");
        }

        [Fact]
        public async Task ConfirmPaymentAsync_WhenOrderNotFound_ShouldThrowException()
        {
            await Assert.ThrowsAsync<ArgumentException>(
                async () => await _service.ConfirmPaymentAsync(999)
            );
        }

        [Fact]
        public async Task CancelOrderAsync_WithPendingOrder_ShouldSucceed()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            };
            var createdOrder = await _service.CreateOrderAsync(orderDto);

            var result = await _service.CancelOrderAsync(createdOrder.Id);

            result.Should().BeTrue();
            var cancelledOrder = await _service.GetOrderByIdAsync(createdOrder.Id);
            cancelledOrder.Status.Should().Be("Cancelled");
        }

        [Fact]
        public async Task CancelOrderAsync_WithPaidOrder_ShouldThrowException()
        {
            var orderDto = new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            };
            var createdOrder = await _service.CreateOrderAsync(orderDto);
            await _service.ConfirmPaymentAsync(createdOrder.Id);

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                async () => await _service.CancelOrderAsync(createdOrder.Id)
            );
            exception.Message.Should().Contain("Cannot cancel a paid order");
        }

        [Fact]
        public async Task GetOrdersByCustomerIdAsync_ShouldReturnCustomerOrders()
        {
            await _service.CreateOrderAsync(new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 1, Quantity = 1 }
                }
            });

            await _service.CreateOrderAsync(new CreateOrderDto
            {
                CustomerId = 1,
                Items = new List<CreateOrderItemDto>
                {
                    new CreateOrderItemDto { ProductId = 2, Quantity = 1 }
                }
            });

            var result = await _service.GetOrdersByCustomerIdAsync(1);

            result.Should().HaveCount(2);
            result.All(o => o.CustomerId == 1).Should().BeTrue();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
