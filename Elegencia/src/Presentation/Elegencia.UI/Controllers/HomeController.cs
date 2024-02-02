using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.DTOs.Meals;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMealService _service;

        public HomeController(IMealService service)
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
