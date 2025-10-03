using ITShopAPI.DTOs;

namespace ITShopAPI.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto orderDto);
        Task<OrderDto?> GetOrderByIdAsync(int id);
        Task<IEnumerable<OrderDto>> GetOrdersByCustomerIdAsync(int customerId);
        Task<OrderDto> ConfirmPaymentAsync(int orderId);
        Task<bool> CancelOrderAsync(int orderId);
    }
}
