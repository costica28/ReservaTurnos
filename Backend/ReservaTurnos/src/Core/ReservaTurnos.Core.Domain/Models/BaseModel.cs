using System.ComponentModel.DataAnnotations;

namespace ReservaTurnos.Core.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
