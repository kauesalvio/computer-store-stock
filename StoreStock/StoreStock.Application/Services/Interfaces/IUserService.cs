using StoreStock.Application.Models.User;
using StoreStock.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserRequestModel request);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(int id, UserRequestModel request);
        Task DeleteUser(int id);
    }
}
