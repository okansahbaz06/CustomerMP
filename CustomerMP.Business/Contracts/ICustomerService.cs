using CustomerMP.Entities.Entities;
using System.Collections.Generic;

namespace CustomerMP.Service.Contracts
{
    public interface ICustomerService
    {
        void CustomerAdd(Customer customer);
        void CustomerDelete(Customer customer);
        void CustomerUpdate(Customer customer);
        List<Customer> GetList();
        Customer GetById(int id);

    }
}
