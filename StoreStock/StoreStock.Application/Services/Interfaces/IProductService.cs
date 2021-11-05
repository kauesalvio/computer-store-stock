using StoreStock.Application.Models.Product;
using StoreStock.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateProduct(ProductRequestModel product);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
