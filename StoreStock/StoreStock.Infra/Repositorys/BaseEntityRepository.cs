using StoreStock.Domain;

namespace StoreStock.Infra.Repositorys
{
    public class BaseEntityRepository<T> : IBaseEntityRepository where T : BaseEntity
    {
    }
}
