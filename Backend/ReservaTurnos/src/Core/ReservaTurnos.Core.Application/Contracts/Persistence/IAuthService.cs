using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<string> Login(AuthRequest authRequest);
        Task<string> Register(User user);
    }
}
