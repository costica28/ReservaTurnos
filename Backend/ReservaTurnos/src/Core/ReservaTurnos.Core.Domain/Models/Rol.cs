using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaTurnos.Core.Domain.Models
{
    [Table("roles")]
    public class Rol: BaseModel
    {
        public string nombre_rol { get; set; } = string.Empty;
    }
}
