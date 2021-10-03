using StoreStock.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IProviderService
    {
        Task CreateProvider(Provider provider);
        Task<IEnumerable> GetAll();
        Task GetProviderId(int id);
        void Update(Provider provider);
    }
}
