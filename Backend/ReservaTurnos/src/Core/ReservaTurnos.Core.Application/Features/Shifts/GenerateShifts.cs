using ReservaTurnos.Commons;
using ReservaTurnos.Core.Application.Contracts.Persistence;
using ReservaTurnos.Core.Application.Exceptions;
using ReservaTurnos.Core.Domain.DTO;
using ReservaTurnos.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ReservaTurnos.Core.Application.Features.Shifts
{
    public class GenerateShifts
    {
        private IUnitOfWork _unitOfWork;

        public GenerateShifts(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Shift>> ProccesAsync(GenerateShiftsRequest generateShiftsRequest)
        {
            bool isFormatValidDateInitial = FormatDateValid.isFormatDateValid(generateShiftsRequest.FechaInicio);
            bool isFormatValidDateFinal = FormatDateValid.isFormatDateValid(generateShiftsRequest.FechaFin);

            if (!isFormatValidDateInitial || !isFormatValidDateFinal)
                throw new BadRequestException("La fecha debe estar en el formato dd/mm/yyyyy");

            DateTime dateInitial = DateTime.ParseExact(generateShiftsRequest.FechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
            DateTime dateFinal = DateTime.ParseExact(generateShiftsRequest.FechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);

            var existService = await _unitOfWork.Repository<Service>().GetByIdAsync(generateShiftsRequest.IdServicio);
            if (existService == null)
                throw new NotFoundException(nameof(Service), generateShiftsRequest.IdServicio);

            var generatedShifts = await _unitOfWork.ShiftRepository.GeneratedShift(generateShiftsRequest.IdServicio, dateInitial, dateFinal);
            if (generatedShifts.Count > 0)
                throw new BadRequestException("No se pueden generar mas turnos con las mismas fechas");

            return (List<Shift>)await _unitOfWork.ShiftRepository.GenerateShift(generateShiftsRequest.IdServicio, dateInitial, dateFinal);
        }

    }
}
