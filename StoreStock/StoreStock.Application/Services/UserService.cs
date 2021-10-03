using StoreStock.Application.Services.Interfaces;
using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
    {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.Create(user);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task GetUserId(int id)
        {
            await _userRepository.GetById(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
