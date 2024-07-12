using CustomerMP.DataLayer.Contracts;
using CustomerMP.Entities.Entities;

namespace CustomerMP.DataLayer
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
     
    }
}
