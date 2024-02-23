using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IReservationService = Elegencia.Application.Abstractions.Services.Manage.IReservationService;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly IAccountService _service;
        private readonly Application.Abstractions.Services.Manage.IReservationService _reservationService;

        public DashboardController(IAccountService service, IReservationService reservationService)
        {
            _service = service;
            _reservationService = reservationService;
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
                ReservationCount = resCount
            };
            return View(dashboard);
        }
        public async Task<IActionResult> Read(int id)
        {
            await _reservationService.Readed(id);
            return RedirectToAction(nameof(Index));
        }
      
    }
}
