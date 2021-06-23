using StoreStock.Domain;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class BaseEntityRepository<T> : IBaseEntityRepository where T : BaseEntity
    {
    }
}
