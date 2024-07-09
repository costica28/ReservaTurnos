using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaTurnos.Core.Domain.Models
{
    [Table("usuarios")]
    public class User: BaseModel
    {
        public string nombre_usuario { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string contrasena { get; set; } = string.Empty;
        public int id_rol { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
