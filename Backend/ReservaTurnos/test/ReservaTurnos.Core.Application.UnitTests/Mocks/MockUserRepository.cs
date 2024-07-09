using AutoFixture;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.UnitTests.Mocks
{
    public class MockUserRepository
    {
        public static void AddDataUserRepository(ShiftsDbContext shiftsDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var users = fixture.CreateMany<User>().ToList();

            users.Add(fixture.Build<User>()
                .With(u => u.Id, 2)
                .With(u => u.email, "prueba2@gmail.com")
                .With(u => u.contrasena, Commons.EncryptDecript.Encript("123", "12ee9a66-700a-494b-bb87-a99c7999f72h"))
                .Create());
            shiftsDbContextFake.Users.AddRange(users);
            shiftsDbContextFake.SaveChanges();
        }
    }
}
