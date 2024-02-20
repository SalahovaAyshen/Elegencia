using Elegencia.Application.Abstractions.Services;
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
            List<SelectListItem> people = new List<SelectListItem>();
            people.Add(new SelectListItem() { Text = "Person", Value = "0" });
            people.Add(new SelectListItem() { Text = "1 Person", Value = "1" });
            people.Add(new SelectListItem() { Text = "2 People", Value = "2" });
            people.Add(new SelectListItem() { Text = "3 People", Value = "3" });
            people.Add(new SelectListItem() { Text = "4 People", Value = "4" });
            people.Add(new SelectListItem() { Text = "5 People", Value = "5" });
            people.Add(new SelectListItem() { Text = "6 People", Value = "6" });
            people.Add(new SelectListItem() { Text = "More", Value = "7" });
            ViewBag.people = people;

            return View();
        }
    }
}
