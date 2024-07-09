using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        IShiftRepository ShiftRepository { get; set; }
        IUserRepository UserRepository { get; set; }

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> Complete();
    }
}
