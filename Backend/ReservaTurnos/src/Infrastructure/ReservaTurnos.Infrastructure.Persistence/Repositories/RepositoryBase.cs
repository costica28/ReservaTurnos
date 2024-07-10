using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReservaTurnos.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        protected readonly ShiftsDbContext _dbContext;

        public RepositoryBase(ShiftsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void DeleteEntity(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void UpdateEntity(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
