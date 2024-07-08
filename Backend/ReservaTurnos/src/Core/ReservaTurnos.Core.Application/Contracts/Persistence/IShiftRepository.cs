using Microsoft.Data.SqlClient;
using ReservaTurnos.Core.Domain.Models;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IShiftRepository: IRepository<Shift>
    {
        Task<IReadOnlyList<Shift>> GenerateShift(int idService, DateTime dateInitial, DateTime dateFinal);
    }
}
