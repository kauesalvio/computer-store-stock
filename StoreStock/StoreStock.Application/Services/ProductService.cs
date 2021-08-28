using StoreStock.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public class ProductService : IGenericService<Product>
    {
        public Task Create(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
