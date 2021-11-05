using StoreStock.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
