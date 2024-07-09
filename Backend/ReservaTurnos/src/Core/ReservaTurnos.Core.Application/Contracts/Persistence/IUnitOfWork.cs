using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IShiftRepository ShiftRepository { get; }
        IUserRepository UserRepository { get; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Complete();
    }
}
