using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReservaTurnos.Infrastructure.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        protected readonly ShiftsDbContext _dbContext;

        public RepositoryBase(ShiftsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEntityAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
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
