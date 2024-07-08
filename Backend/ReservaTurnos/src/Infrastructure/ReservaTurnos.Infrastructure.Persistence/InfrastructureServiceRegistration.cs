using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Repositories;

namespace ReservaTurnos.Infrastructure.Persistence
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShiftsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IShiftRepository, ShiftRepository>();

            return services;
        }
    }
}
