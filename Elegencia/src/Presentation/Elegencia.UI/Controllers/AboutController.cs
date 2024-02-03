using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = await _service.GetAll();
            return View(aboutVM);
        }
    }
}
