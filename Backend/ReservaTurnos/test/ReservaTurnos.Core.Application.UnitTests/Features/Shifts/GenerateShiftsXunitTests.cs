using Moq;
using NSubstitute;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Features.Shifts;
using ReservaTurnos.Core.Application.UnitTests.Mocks;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using ReservaTurnos.Infrastructure.Persistence.Repositories;
using System.Globalization;
using Xunit;

namespace ReservaTurnos.Core.Application.UnitTests.Features.Shifts
{
    public class GenerateShiftsXunitTests
    {
        private Mock<UnitOfWork> _unitOfWork;
        private IShiftRepository _shiftRepository;

        public GenerateShiftsXunitTests() 
        {
            _unitOfWork = MockInstanceDbContext.GetUnitWork();
            _shiftRepository = Substitute.For<IShiftRepository>();
            MockServiceRepository.AddDataServiceRepository(_unitOfWork.Object.shiftsDbContext);
        }

        [Fact]
        public void NotFoundService()
        {
            var generateShifts = new GenerateShifts(_unitOfWork.Object);
            var request = new GenerateShiftsRequest()
            {
                FechaFin = "09/07/2024",
                FechaInicio = "09/07/2024",
                IdServicio = 1
            };
            var exception = Record.Exception(generateShifts.ProccesAsync(request).Wait);
            Assert.Contains($"Entity {nameof(Service)} {request.IdServicio} no fue encontrado", exception.Message);
        }

        [Fact]
        public void FormatDatesInvalid()
        {
            var generateShifts = new GenerateShifts(_unitOfWork.Object);
            var request = new GenerateShiftsRequest()
            {
                FechaFin = "09/07/2024",
                FechaInicio = "2024/20/21",
                IdServicio = 1
            };
            var exception = Record.Exception(generateShifts.ProccesAsync(request).Wait);
            Assert.Contains($"La fecha debe estar en el formato dd/mm/yyyyy", exception.Message);
        }

        [Fact]
        public async Task GetShiftsGenered()
        {
            var generateShifts = new GenerateShifts(_unitOfWork.Object);
            var request = new GenerateShiftsRequest()
            {
                FechaFin = "09/07/2024",
                FechaInicio = "09/07/2024",
                IdServicio = 2
            };
            DateTime dateInitial = DateTime.ParseExact(request.FechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime dateFinal = DateTime.ParseExact(request.FechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            var shifts = new List<Shift>()
            {
                new Shift { estado = 1, fecha_turno = dateInitial, id_turno = 1, id_servicio = request.IdServicio, hora_apertura = new TimeSpan(08, 30, 00), hora_cierre = new TimeSpan(09,00,00) },
                new Shift { estado = 1, fecha_turno = dateInitial, id_turno = 2, id_servicio = request.IdServicio, hora_apertura = new TimeSpan(09, 00, 00), hora_cierre = new TimeSpan(09,30,00) },
                new Shift { estado = 1, fecha_turno = dateInitial, id_turno = 3, id_servicio = request.IdServicio, hora_apertura = new TimeSpan(09, 30, 00), hora_cierre = new TimeSpan(10,00,00) },
                new Shift { estado = 1, fecha_turno = dateInitial, id_turno = 4, id_servicio = request.IdServicio, hora_apertura = new TimeSpan(10, 00, 00), hora_cierre = new TimeSpan(10,30,00) },
            };
            _shiftRepository.GenerateShift(request.IdServicio, dateInitial, dateFinal).Returns(shifts);
            _unitOfWork.Object.ShiftRepository = _shiftRepository;

            var result = await generateShifts.ProccesAsync(request);
            Assert.IsType<List<Shift>>(result);
            Assert.True(result.Count() > 0);
        }
    }
}
