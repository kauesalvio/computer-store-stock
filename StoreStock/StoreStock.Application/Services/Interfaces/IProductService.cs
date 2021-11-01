using StoreStock.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
