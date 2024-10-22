using CustomerMP.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerMP.DataLayer.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUserByUsernameAndPassword(string username, string password);
        public User GetUserByUsername(string username);

    }
}
