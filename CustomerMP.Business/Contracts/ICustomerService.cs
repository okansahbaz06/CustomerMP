using CustomerMP.Entities.Entities;
using System.Collections.Generic;

namespace CustomerMP.Service.Contracts
{
    public interface ICustomerService
    {
        void CustomerAdd(Customers customer);
        void CustomerDelete(Customers customer);
        void CustomerUpdate(Customers customer);
        List<Customers> GetList();
        Customers GetById(int id);

    }
}
