using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.MailService;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IReservationService = Elegencia.Application.Abstractions.Services.Manage.IReservationService;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly IAccountService _service;
        private readonly Application.Abstractions.Services.Manage.IReservationService _reservationService;
        private readonly IMailService _mailService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(IAccountService service, IReservationService reservationService, IMailService mailService, UserManager<AppUser> userManager)
        {
            _service = service;
            _reservationService = reservationService;
            _mailService = mailService;
            _userManager = userManager;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index()
        {
            int count = await _service.UserCount();
            int resCount = await _reservationService.ReservationCount();
            IQueryable<Reservation> reservations = await _reservationService.GetAll();
            DashboardVM dashboard = new DashboardVM
            {
                UserCount = count,
                Reservations = reservations,
                ReservationCount = resCount,
            };
            return View(dashboard);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Read(int id)
        {
         
            await _reservationService.Accept(id);

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Reject(int id)
        {
            await _reservationService.Reject(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
