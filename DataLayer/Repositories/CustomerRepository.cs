using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using CustomerMP.DataLayer.UnitOfWork;
using CustomerMP.Entities.Entities;

namespace CustomerMP.DataLayer.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork, CustomerMP_DBContext customerMP_DBContext) : base(unitOfWork,customerMP_DBContext)
        {
        }
    }
}
