using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Infrastructure.Persistence.Repositories
{
    public class RolRepository: RepositoryBase<Rol>, IRolRepository
    {
        public RolRepository(ShiftsDbContext context) : base(context) { }
    }
}
