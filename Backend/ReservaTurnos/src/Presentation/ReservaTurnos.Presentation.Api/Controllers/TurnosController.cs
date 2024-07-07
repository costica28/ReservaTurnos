using Microsoft.AspNetCore.Mvc;

namespace ReservaTurnos.Presentation.Api.Controllers
{
    [Route("[controller]")]
    public class TurnosController : ControllerBase
    {
        [HttpGet]
        [Route("GenerateShifts")]
        public IActionResult GenerateShifts()
        {
            return Ok();
        }
    }
}
