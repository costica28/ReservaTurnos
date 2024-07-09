using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaTurnos.Core.Domain.Models
{
    [Table("turnos")]
    public class Shift
    {
        public Shift()
        {
            //Services = new HashSet<Service>();
        }

        [Key]        
        public int id_turno { get; set; }
        public int id_servicio { get; set; }
        public DateTime fecha_turno { get; set; }
        public TimeSpan hora_apertura { get; set; }
        public TimeSpan hora_cierre { get; set; }
        public int estado { get; set; }
        //public virtual ICollection<Service> Services { get; set; }

    }
}
