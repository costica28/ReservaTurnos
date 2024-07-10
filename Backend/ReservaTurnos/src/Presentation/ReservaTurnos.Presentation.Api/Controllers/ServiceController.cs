using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Presentation.Api.Errors;
using ReservaTurnos.Presentation.Api.Middleware.Jwt;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ReservaTurnos.Presentation.Api.Controllers
{
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene toda la información de los servicios que existen hasta la fecha
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna el listado de comercios", typeof(Shift))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Requiere que el usuario este autenticado")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(CodeErrorException))]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new { data = await _unitOfWork.Repository<Service>().GetAllAsync() });
        }
    }
}
