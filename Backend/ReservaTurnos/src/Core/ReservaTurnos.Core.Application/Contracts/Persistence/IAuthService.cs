using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Core.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<string> Login(AuthRequest authRequest);
        Task<string> Register(User user);
    }
}
