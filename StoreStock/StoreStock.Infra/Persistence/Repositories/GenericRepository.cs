using Microsoft.EntityFrameworkCore;
using StoreStock.Domain;
using StoreStock.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreStock.Infra.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Query().SingleOrDefaultAsync(e => e.Id == id); 
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Save() => await _dbContext.SaveChangesAsync();

        protected IQueryable<T> Query() => _dbSet.AsNoTracking().Where(entity => !entity.IsActive);
    }
}
