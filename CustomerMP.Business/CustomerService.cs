using CustomerMP.DataLayer.Contracts;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using System.Collections.Generic;

namespace CustomerMP.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void CustomerAdd(Customer customer)
        {
            _customerRepository.Insert(customer);
        }

        public void CustomerDelete(Customer customer)
        {
            _customerRepository.Delete(customer);

        }

        public void CustomerUpdate(Customer customer)
        {
            _customerRepository.Update(customer);

        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);

        }

        public List<Customer> GetList()
        {
            return _customerRepository.GetAll();

        }

    }
}
