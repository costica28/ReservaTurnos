using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        void AddEntity(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
