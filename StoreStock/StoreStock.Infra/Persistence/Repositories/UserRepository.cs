using StoreStock.Domain.Entities;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
