using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Features.Shifts;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Presentation.Api.Errors;
using ReservaTurnos.Presentation.Api.Middleware.Jwt;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ReservaTurnos.Presentation.Api.Controllers
{
    [Route("[controller]")]
    public class ShiftsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ShiftsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Genera los turnos de un servicio
        /// </summary>
        /// <param name="generateShiftsRequest">Contiene los parametros de entrada para realizar la generacion de los turnos del servicio: <br/></param>
        /// <remarks>
        /// <b>1 - fechaInicio:</b> Es la fecha de inicio del servicio donde empieza a generarse el primer turno <br/><br/>
        /// <b>2 - fechaFin:</b> Es la fecha donde se culmina el servicio <br/><br/>
        /// <b>3 - idServicio:</b> Es el id del servicio que se encuentra en la tabla servicios de la base de datos
        /// </remarks>
        /// <returns>El listado de turnos generados</returns>
        [HttpPost]
        [Authorize]
        [Route("GenerateShifts")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna el listado de turnos generados", typeof(Shift))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Sucede un error interno en la logica de negocio", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "El registro que se consulta no existe", typeof(CodeErrorException))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Requiere que el usuario este autenticado")]        
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "", typeof(CodeErrorException))]
        public async Task<IActionResult> GenerateShifts([FromBody] GenerateShiftsRequest generateShiftsRequest)
        {
            GenerateShifts generateShifts = new GenerateShifts(_unitOfWork);

            var response = await generateShifts.ProccesAsync(generateShiftsRequest);
            return Ok(new {data = response });
        }
    }
}
