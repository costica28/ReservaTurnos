using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Domain.DTO
{
    public class InfoUser
    {
        public int idUser { get; set; }
        public string nombre_usuario { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public int id_rol { get; set; }
    }
}
