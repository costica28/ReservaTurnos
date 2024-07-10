using System;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IShiftRepository ShiftRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IRolRepository RolRepository { get; set; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Complete();
    }
}
