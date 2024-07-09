using ReservaTurnos.Commons;
using System.ComponentModel.DataAnnotations;

namespace ReservaTurnos.Core.Domain.DTO
{
    public class GenerateShiftsRequest
    {
        [Required]
        public string FechaInicio { get; set; } = string.Empty;
        [Required]
        public string FechaFin { get; set; } = string.Empty;
        [Required]
        public int IdServicio { get; set; }
    }
}
