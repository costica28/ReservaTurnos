using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Features.Auth;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Presentation.Api.Controllers
{
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public AuthController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
        {
            AuthService authService = new AuthService(_configuration, _userRepository);
            return Ok(await authService.Login(authRequest));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
        {
            AuthService authService = new AuthService(_configuration, _userRepository);
            return Ok(await authService.Register(registrationRequest));
        }
    }
}
