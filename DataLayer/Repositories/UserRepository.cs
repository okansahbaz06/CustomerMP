using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using CustomerMP.DataLayer.UnitOfWork;
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerMP.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork, CustomerMP_DBContext customerMP_DBContext) : base(unitOfWork, customerMP_DBContext)
        {
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
