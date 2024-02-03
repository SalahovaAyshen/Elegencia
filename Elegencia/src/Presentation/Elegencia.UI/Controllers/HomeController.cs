using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController(IHomeService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM meals = await _service.GetAll();
           
            return View(meals);
        }
    }
}
