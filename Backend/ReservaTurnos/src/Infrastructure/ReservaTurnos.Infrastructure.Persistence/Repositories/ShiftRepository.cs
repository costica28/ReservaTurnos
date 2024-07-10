using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class ShiftRepository: RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(ShiftsDbContext context) : base(context) { }

        public async Task<IReadOnlyList<Shift>> GenerateShift(int idService, DateTime dateInitial, DateTime dateFinal)
        {
           return await _dbContext.Database.SqlQueryRaw<Shift>("SP_GenerarTurnos @IdServicio, @FechaInicio, @FechaFin",
                new SqlParameter("@IdServicio", idService), new SqlParameter("@FechaInicio", dateInitial), new SqlParameter("@FechaFin", dateFinal)).ToListAsync();
        }

        public async Task<IReadOnlyList<Shift>> GeneratedShift(int idService, DateTime dateInitial, DateTime dateFinal)
        {
            var result =  await _dbContext.Shifts.Where(x=> x.id_servicio ==  idService && x.fecha_turno >= dateInitial && x.fecha_turno <= dateFinal).ToListAsync();
            return result;
        }
    }
}
