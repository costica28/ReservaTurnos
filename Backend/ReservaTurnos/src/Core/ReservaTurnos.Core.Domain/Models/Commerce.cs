using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaTurnos.Core.Domain.Models
{
    [Table("comercios")]
    public class Commerce
    {
        public Commerce() {
            //Services = new HashSet<Service>();
        }

        [Key]
        public int id_comercio { get; set; }
        public string nom_comercio { get; set; }
        public int aforo_maximo { get; set; }

        //public virtual ICollection<Service> Services { get; set; }
    }
}
