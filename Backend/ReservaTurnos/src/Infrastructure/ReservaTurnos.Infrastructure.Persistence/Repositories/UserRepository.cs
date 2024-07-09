using Microsoft.EntityFrameworkCore;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Persistence;

namespace ReservaTurnos.Infrastructure.Persistence.Repositories
{
    public class UserRepository:RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ShiftsDbContext context) : base(context) { }

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                return await _dbContext.Users.Where(x => x.email == email).FirstOrDefaultAsync();           
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
