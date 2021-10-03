using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
