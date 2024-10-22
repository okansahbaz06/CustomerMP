using CustomerMP.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerMP.Service.Contracts
{
    public interface ICustomerService
    {
        Task<Customer> CustomerAddAsync(Customer customer);
        void CustomerDelete(Customer customer);
        void CustomerUpdate(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);

    }
}
