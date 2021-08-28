using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Save();
    }
}
