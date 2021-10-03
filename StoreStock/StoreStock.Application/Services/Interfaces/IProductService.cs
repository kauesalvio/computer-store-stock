using StoreStock.Domain.Entities;
using System.Collections;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(Product product);
        Task<IEnumerable> GetAll();
        Task GetProductId(int id);
        void Update(Product product);
    }
}
