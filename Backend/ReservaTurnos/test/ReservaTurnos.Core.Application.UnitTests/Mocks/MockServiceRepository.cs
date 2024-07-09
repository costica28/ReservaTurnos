using AutoFixture;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Persistence;

namespace ReservaTurnos.Core.Application.UnitTests.Mocks
{
    public class MockServiceRepository
    {
        public static void AddDataServiceRepository(ShiftsDbContext shiftsDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var services = fixture.CreateMany<Service>().ToList();

            services.Add(fixture.Build<Service>()
                .With(u => u.id_servicio, 2)
                .Create());
            shiftsDbContextFake.Services.AddRange(services);
            shiftsDbContextFake.SaveChanges();
        }
    }
}
