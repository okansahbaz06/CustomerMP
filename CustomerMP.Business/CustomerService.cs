using CustomerMP.DataLayer.Contracts;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using System.Collections.Generic;

namespace CustomerMP.Service
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void CustomerAdd(Customers customer)
        {
            _customerRepository.Insert(customer);
        }

        public void CustomerDelete(Customers customer)
        {
            _customerRepository.Delete(customer);

        }

        public void CustomerUpdate(Customers customer)
        {
            _customerRepository.Update(customer);

        }

        public Customers GetById(int id)
        {
            return _customerRepository.GetById(id);

        }

        public List<Customers> GetList()
        {
            return _customerRepository.GetAll();

        }

    }
}
