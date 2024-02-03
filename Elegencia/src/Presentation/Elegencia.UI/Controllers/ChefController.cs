using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class ChefController : Controller
    {
        private readonly IChefService _service;

        public ChefController(IChefService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            ChefVM chefVM = await _service.GetAll();
            return View(chefVM);
        }
        public async Task<IActionResult> AboutChef(int id)
        {
            Chef chef = await _service.GetInfo(id);
            return View(chef);
        }
    }
}
