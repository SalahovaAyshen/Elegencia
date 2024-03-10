using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.MailService;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class ReservationService : Application.Abstractions.Services.Manage.IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IAccountService _service;
        private readonly IMailService _mailService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationService(IReservationRepository reservationRepository, IAccountService service, IMailService mailService, UserManager<AppUser> userManager)
        {
            _reservationRepository = reservationRepository;
            _service = service;
            _mailService = mailService;
            _userManager = userManager;
        }
        public async Task<IQueryable<Reservation>> GetAll()
        {
            IQueryable<Reservation> reservations = _reservationRepository.GetAllWithOrder(expression:e=>e.IsDeleted==false);
            return reservations;
        }

        public async Task Accept(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Reservation reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) throw new NotFoundException("Not found id");
            AppUser user = await _userManager.FindByEmailAsync(reservation.Email);
            await _mailService.SendEmailAsync(user.Email, "Reservation", $"<body style=\"margin: 0; padding: 0; background-color: #05161A;\">\n    <div class=\"email-wrapper\" style=\"display: flex; justify-content: center; align-items: center;flex-direction: column; margin-top: 50px;\">\n        <div class=\"email\" style=\"padding: 50px; color: white; border-radius: 16px; border: 1px dashed #ffd28d;\">\n            <h1 style=\"text-align: center; margin-top:0; margin-bottom: 10px;\">Welocome, to <i style=\"color: #ffd28d\">Elegencia</i> !</h1>\n                     <div class=\"btn-wrapper\" style=\"display: flex; justify-content: center; align-items: center; margin-top: 50px;\">\n                <h5 ' style=\"display: flex; text-align:center; justify-content: center; align-items: center; flex-direction: column; background-color: transparent; border: 0.5px solid #ffd28d; color: white; padding: 10px 18px; border-radius: 8px; cursor: pointer;\">Your reservation has been registered! Have a Good Day! ❤</h5>\n            </div>\n        </div>\n\n           <div class=\"image-wrapper\" style=\"border-radius: 8px; display: flex; justify-content: center; align-items: center; width: 675px; height: 333px; overflow: hidden; border-radius: 16px; margin-top: 50px;\">\n            <img style=\"object-fit: cover; object-position: center; display: flex; justify-content: center;\" src=\"https://images.pexels.com/photos/260922/pexels-photo-260922.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\" alt=\"\">\n        </div>\n    </div>\n</body>", true);
            _reservationRepository.Delete(reservation);
            await _reservationRepository.SaveChangesAsync();
        }
        public async Task Reject(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Reservation reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) throw new NotFoundException("Not found id");
            AppUser user = await _userManager.FindByEmailAsync(reservation.Email);
            await _mailService.SendEmailAsync(user.Email, "Reservation", $"<body style=\"margin: 0; padding: 0; background-color: #05161A;\">\n    <div class=\"email-wrapper\" style=\"display: flex; justify-content: center; align-items: center;flex-direction: column; margin-top: 50px;\">\n        <div class=\"email\" style=\"padding: 50px; color: white; border-radius: 16px; border: 1px dashed #ffd28d;\">\n            <h1 style=\"text-align: center; margin-top:0; margin-bottom: 10px;\">Welocome, to <i style=\"color: #ffd28d\">Elegencia</i> !</h1>\n                     <div class=\"btn-wrapper\" style=\"display: flex; justify-content: center; align-items: center; margin-top: 50px;\">\n                <h5 ' style=\"display: flex; text-align:center; justify-content: center; align-items: center; flex-direction: column; background-color: transparent; border: 0.5px solid #ffd28d; color: white; padding: 10px 18px; border-radius: 8px; cursor: pointer;\">Your reservation was not registered! Please take a look at other days!❤</h5>\n            </div>\n        </div>\n\n           <div class=\"image-wrapper\" style=\"border-radius: 8px; display: flex; justify-content: center; align-items: center; width: 675px; height: 333px; overflow: hidden; border-radius: 16px; margin-top: 50px;\">\n            <img style=\"object-fit: cover; object-position: center; display: flex; justify-content: center;\" src=\"https://images.pexels.com/photos/260922/pexels-photo-260922.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\" alt=\"\">\n        </div>\n    </div>\n</body>", true);
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
