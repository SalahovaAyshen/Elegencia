using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Elegencia.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ReservationVM reservationVM)
        {
            if (await _reservationService.Post(reservationVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-light\" role=\"alert\">\r\n  Check the email you entered within 20 minutes \r\n</div>";
                return RedirectToAction("Index", "Home");
            }
            return View(reservationVM);
        }
    }
}
