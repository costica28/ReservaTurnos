using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Features.Auth;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Presentation.Api.Errors;
using Swashbuckle.AspNetCore.Annotations;

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

        /// <summary>
        /// Este metodo permite la autenticacion del usuario ya creado
        /// </summary>
        /// <param name="authRequest">Entidad con los parametros para realizar la authenticacion</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [SwaggerResponse(StatusCodes.Status200OK, "Se obtiene el token con las credenciales correctas", typeof(Token))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Sucede un error interno en la logica de negocio", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encuentra el registro", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(CodeErrorException))]
        public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
        {
            AuthService authService = new AuthService(_configuration, _userRepository);
            return Ok(await authService.Login(authRequest));
        }

        /// <summary>
        /// Permite registrar un nuevo usuario y retorna el token
        /// </summary>
        /// <param name="registrationRequest">Entidad que contiene los datos para el registro del nuevo usuario</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        [SwaggerResponse(StatusCodes.Status200OK, "Registra un nuevo usuario y retorna el token", typeof(Token))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Sucede un error interno en la logica de negocio", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encuentra el registro", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(CodeErrorException))]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest registrationRequest)
        {
            AuthService authService = new AuthService(_configuration, _userRepository);
            return Ok(await authService.Register(registrationRequest));
        }
    }
}
