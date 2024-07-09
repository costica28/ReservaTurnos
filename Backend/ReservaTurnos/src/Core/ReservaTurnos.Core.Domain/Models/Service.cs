using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaTurnos.Core.Domain.Models
{
    [Table("servicios")]
    public class Service
    {
        [Key]
        public int id_servicio { get; set; }
        public int id_comercio { get; set; }
        public string nom_servicio { get; set; } = string.Empty;
        public TimeSpan hora_apertura { get; set; }
        public TimeSpan hora_cierre { get; set; }
        public int duracion { get; set; }
        //public virtual Commerce? Commerce { get; set; }
        //public virtual Shift? Shift { get; set; }
        
    }
}
