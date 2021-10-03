using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class ProviderRepository : GenericRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
