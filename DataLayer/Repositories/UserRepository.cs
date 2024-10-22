using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerMP.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        CustomerMP_DBContext context = new CustomerMP_DBContext();

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public User GetUserByUsername(string username)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
