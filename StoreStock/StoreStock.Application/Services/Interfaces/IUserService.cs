using StoreStock.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(User user);
        Task<IEnumerable> GetAll();
        Task GetUserId(int id);
        void Update(User user);
    }
}
