using ReservaTurnos.Core.Domain.Models;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
