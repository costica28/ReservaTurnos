using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
