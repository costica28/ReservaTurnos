using Moq;
using NSubstitute;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Features.Auth;
using ReservaTurnos.Core.Application.UnitTests.Mocks;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace ReservaTurnos.Core.Application.UnitTests.Features.Auth
{
    public class AuthServiceXunitTests
    {
        private readonly Mock<Microsoft.Extensions.Configuration.IConfiguration> _configuration;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private IRolRepository _rolRepository;

        public AuthServiceXunitTests()
        {
            _rolRepository = Substitute.For<IRolRepository>();
            _unitOfWork = MockInstanceDbContext.GetUnitWork();
            _configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            _configuration.Setup(c => c["KeyEncriptDecript"]).Returns("12ee9a66-700a-494b-bb87-a99c7999f72h");
            _configuration.Setup(c => c["JwtToken:SecretKey"]).Returns("12ee9a66-700a-494b-bb87-a99c7999f72j");
            _configuration.Setup(c => c["JwtToken:Issuer"]).Returns("https://localhost:7284");
            _configuration.Setup(c => c["JwtToken:Audience"]).Returns("https://localhost:7284");
            _configuration.Setup(c => c["JwtToken:ExpireTime"]).Returns("10");

            MockUserRepository.AddDataUserRepository(_unitOfWork.Object.shiftsDbContext);
        }

        [Fact]
        private async Task LoginSucces()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new AuthRequest()
            {
                contrasena = "123",
                email = "prueba2@gmail.com"
            };

            var result = await auth.Login(request);
            Assert.IsType<Token>(result);

        }

        [Fact]
        private void LoginCredentialInvalid()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new AuthRequest()
            {
                contrasena = "12334",
                email = "prueba2@gmail.com"
            };

            var exception = Record.Exception(auth.Login(request).Wait);
            Assert.True(exception.Message.Contains("Las credenciales son incorrectas") == true);
        }

        [Fact]
        private void LoginEmailNotFound()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new AuthRequest()
            {
                contrasena = "123",
                email = "prueba@gmail.com"
            };

            var exception = Record.Exception(auth.Login(request).Wait);
            Assert.True(exception.Message.Contains($"Entity {nameof(User)} {request.email} no fue encontrado") == true);
        }


        [Fact]
        private async Task RegisterSucces()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new RegistrationRequest()
            {
                id_rol = 1,
                nombre_usuario = "prueba 3",
                contrasena = "123",
                email = "prueba3@gmail.com"
            };
            _rolRepository.GetByIdAsync(request.id_rol).Returns(new Rol() { Id = 1, nombre_rol = "Administrador" });
            _unitOfWork.Object.RolRepository = _rolRepository;

            var result = await auth.Register(request);
            Assert.IsType<Token>(result);
        }

        [Fact]
        private void RegisterEmailExist()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new RegistrationRequest()
            {
                id_rol = 1,
                nombre_usuario = "prueba 2",
                contrasena = "123",
                email = "prueba2@gmail.com"
            };

            var exception = Record.Exception(auth.Register(request).Wait);
            Assert.Contains("El email ya fue tomado por otra cuenta", exception.Message);
        }

        [Fact]
        private async void RegisterNotFoundRol()
        {
            var auth = new AuthService(_configuration.Object, _unitOfWork.Object);
            var request = new RegistrationRequest()
            {
                id_rol = 2,
                nombre_usuario = "prueba 2",
                contrasena = "123",
                email = "prueba@gmail.com"
            };
            _rolRepository.GetByIdAsync(request.id_rol).Returns((Rol)null);
            _unitOfWork.Object.RolRepository = _rolRepository;
            
            var exception = Record.Exception(auth.Register(request).Wait);
            Assert.Contains("El rol ingresado no existe", exception.Message);
        }

    }
}
