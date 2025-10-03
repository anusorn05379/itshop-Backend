using ITShopAPI.DTOs;
using ITShopAPI.Models;
using ITShopAPI.Repositories;

namespace ITShopAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address
            });
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return null;

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto customerDto)
        {
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Address = customerDto.Address,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var createdCustomer = await _customerRepository.AddAsync(customer);

            return new CustomerDto
            {
                Id = createdCustomer.Id,
                Name = createdCustomer.Name,
                Email = createdCustomer.Email,
                Phone = createdCustomer.Phone,
                Address = createdCustomer.Address
            };
        }

        public async Task<CustomerDto> UpdateCustomerAsync(int id, UpdateCustomerDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return null;

            customer.Name = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.Phone = customerDto.Phone;
            customer.Address = customerDto.Address;
            customer.UpdatedDate = DateTime.Now;

            await _customerRepository.UpdateAsync(customer);

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address
            };
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return false;

            await _customerRepository.DeleteAsync(customer);
            return true;
        }
    }
}
