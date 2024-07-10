using ReservaTurnos.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IShiftRepository: IRepository<Shift>
    {
        Task<IReadOnlyList<Shift>> GenerateShift(int idService, DateTime dateInitial, DateTime dateFinal);
        Task<IReadOnlyList<Shift>> GeneratedShift(int idService, DateTime dateInitial, DateTime dateFinal);
    }
}
