using CustomerMP.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.DataLayer.Contracts
{
    public interface IUserRepository
    {
        public User GetUserByUsernameAndPassword(string username, string password);
        public User GetUserByUsername(string username);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(User user);

    }
}
