using CustomerMP.DataLayer.Contracts;
using CustomerMP.DataLayer.Repositories;
using CustomerMP.Entities.Entities;
using CustomerMP.Service.Contracts;
using System.Threading.Tasks;

namespace CustomerMP.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _userRepository.GetUserByUsernameAndPassword(username, password);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public async Task<User> UserAddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public void UserDelete(User user)
        {
            _userRepository.Delete(user);

        }

        public void UserUpdate(User user)
        {
            _userRepository.Update(user);

        }
    }
}
