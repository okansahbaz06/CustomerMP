using CustomerMP.DataLayer.Contracts;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMP.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CustomerAddAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        public void CustomerDelete(Customer customer)
        {
            _customerRepository.Delete(customer);

        }

        public void CustomerUpdate(Customer customer)
        {
            _customerRepository.Update(customer);

        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);

        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAll().ToListAsync();

        }

    }
}
