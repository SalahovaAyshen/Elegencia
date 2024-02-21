using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<bool> Post(ReservationVM reservationVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            Regex regex = new Regex(@"^(([0-9a-z]|[a-z0-9(\.)?a-z]|[a-z0-9])){1,}(\@)[a-z((\-)?)]{1,}(\.)([a-z]{1,}(\.))?([a-z]{2,3})$");
            if (!regex.IsMatch(reservationVM.Email))
            {
                modelState.AddModelError("Email", "The wrong structure");
                return false;
            }
            if (reservationVM.NumberOfPeople <= 0)
            {
                modelState.AddModelError("NumberOfPeople", "Number of people can't be 0 or negative number");
                return false;
            }
            if(DateTime.Now.Year>reservationVM.Date.Year)
            {
                modelState.AddModelError("Date", "It is not possible to reserve past years");
                return false;
            }
            if (DateTime.Now.Month>reservationVM.Date.Month)
            {
                modelState.AddModelError("Date", "It is not possible to reserve past months");
                return false;
            }
            if (DateTime.Now.Day > reservationVM.Date.Day)
            {
                modelState.AddModelError("Date", "It is not possible to reserve past days");
                return false;
            }

            if (DateTime.Now.Day==reservationVM.Date.Day && 
                DateTime.Now.Month==reservationVM.Date.Month && 
                DateTime.Now.Year==reservationVM.Date.Year && 
                DateTime.Now.Hour > reservationVM.Time.Hour - 4) 
            {
                modelState.AddModelError("Time", "The reserve must be 4 hours before the appointment");
                return false;
            }

            await _reservationRepository.AddAsync(new Domain.Entities.Reservation
            {
                Name = reservationVM.Name,
                Email = reservationVM.Email,
                NumberOfPeople = reservationVM.NumberOfPeople,
                ArrivalDateTime = reservationVM.Date.AddHours(reservationVM.Time.Hour).AddMinutes(reservationVM.Time.Minute),
            }); 
            await _reservationRepository.SaveChangesAsync();
            return true;
        }
    }
}
