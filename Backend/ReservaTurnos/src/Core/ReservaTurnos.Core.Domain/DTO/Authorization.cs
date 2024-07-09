using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Domain.DTO
{
    public class Authorization
    {
        public int id { get; set; }
        public string email { get; set; }

        public Token token { get; set; }

    }
}
