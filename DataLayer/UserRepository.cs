using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.DBContext;
using CustomerMP.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerMP.DataLayer
{
    public class UserRepository :IUserRepository
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

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
