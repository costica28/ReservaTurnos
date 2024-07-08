using ReservaTurnos.Commons;
using System.ComponentModel.DataAnnotations;

namespace ReservaTurnos.Core.Domain.DTO
{
    public class GenerateShiftsRequest
    {
        [Required]
        [CustomDateFormat("dd/MM/yyyy")]
        public string FechaInicio { get; set; } = string.Empty;
        [Required]
        [CustomDateFormat("dd/MM/yyyy")]
        public string FechaFin { get; set; } = string.Empty;
        [Required]
        public int IdServicio { get; set; }
    }
}
