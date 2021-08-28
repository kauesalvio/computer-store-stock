using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreStock.Application.Services
{
    public interface IGenericService<T>
    {
        Task Create(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
