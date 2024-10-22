using CustomerMP.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.Service.Contracts
{
    public interface IUserService
    {
        User GetUserByUsernameAndPassword(string username, string password);
        User GetUserByUsername(string username);
        Task<User> UserAddAsync(User user);
        void UserDelete(User user);
        void UserUpdate(User user);
    }
}
