using StoreStock.Domain.Entities;
using StoreStock.Domain.Interfaces;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
