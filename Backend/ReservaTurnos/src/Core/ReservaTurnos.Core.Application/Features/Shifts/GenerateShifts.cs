using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Exceptions;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using System.Globalization;

namespace ReservaTurnos.Core.Application.Features.Shifts
{
    public class GenerateShifts
    {
        private IShiftRepository _shiftRepository;
        private IRepository<Service> _serviceRepository;

        public GenerateShifts(IShiftRepository shiftRepository, IRepository<Service> serviceRepository)
        {
            _shiftRepository = shiftRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<List<Shift>> ProccesAsync(GenerateShiftsRequest generateShiftsRequest)
        {
            DateTime dateInitial = DateTime.ParseExact(generateShiftsRequest.FechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime dateFinal = DateTime.ParseExact(generateShiftsRequest.FechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            var existService = await _serviceRepository.GetByIdAsync(generateShiftsRequest.IdServicio);
            if (existService == null)
                throw new NotFoundException(nameof(Service), generateShiftsRequest.IdServicio);

            return (List<Shift>)await _shiftRepository.GenerateShift(generateShiftsRequest.IdServicio, dateInitial, dateFinal);
        }

    }
}
