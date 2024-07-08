namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task AddEntityAsync(T entity);
        Task DeleteEntityAsync(T entity);
        Task UpdateEntityAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
