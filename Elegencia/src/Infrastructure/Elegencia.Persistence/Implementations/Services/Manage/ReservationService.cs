using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<IQueryable<Reservation>> GetAll()
        {
            IQueryable<Reservation> reservations = _reservationRepository.GetAll();
            return reservations;
        }

        public async Task Readed(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Reservation reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) throw new NotFoundException("Not found id");
            _reservationRepository.Delete(reservation);
            await _reservationRepository.SaveChangesAsync();
        }

        public async Task<int> ReservationCount()
        {
            int count = await _reservationRepository.CountAsync();
            return count;
        }
    }
}
