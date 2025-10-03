using ITShopAPI.DTOs;

namespace ITShopAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto customerDto);
        Task<CustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
