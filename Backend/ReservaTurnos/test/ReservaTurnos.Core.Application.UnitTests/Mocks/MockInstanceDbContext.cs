using Microsoft.EntityFrameworkCore;
using Moq;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using ReservaTurnos.Infrastructure.Persistence.Repositories;
using System;

namespace ReservaTurnos.Core.Application.UnitTests.Mocks
{
    public static class MockInstanceDbContext
    {
        public static Mock<UnitOfWork> GetUnitWork()
        {
            var options = new DbContextOptionsBuilder<ShiftsDbContext>()
                .UseInMemoryDatabase(databaseName: $"ShiftsDbContext-{Guid.NewGuid()}").Options;

            var shiftsDbContextFake = new ShiftsDbContext(options);

            shiftsDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(shiftsDbContextFake);
            return mockUnitOfWork;
        }
    }
}
