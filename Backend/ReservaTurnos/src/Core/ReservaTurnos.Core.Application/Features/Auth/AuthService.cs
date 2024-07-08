using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Core.Application.Features.Auth
{
    public class AuthService
    {
        private IRepository<User> _UserRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<string> Login(AuthRequest authRequest)
        {

        }
    }
}
