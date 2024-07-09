using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using System.Collections;

namespace ReservaTurnos.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repositories;
        private readonly ShiftsDbContext _dbContext;
        private IShiftRepository _shiftRepository;
        private IUserRepository _userRepository;


        public IShiftRepository ShiftRepository => _shiftRepository ?? new ShiftRepository(_dbContext);

        public IUserRepository UserRepository =>_userRepository ?? new UserRepository(_dbContext);

        public UnitOfWork(ShiftsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShiftsDbContext shiftsDbContext => _dbContext;

        public async Task<int> Complete()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var respositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(
                    respositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)_repositories[type];

        }
    }
}
