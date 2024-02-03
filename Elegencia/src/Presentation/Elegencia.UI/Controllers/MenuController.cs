using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _service;

        public MenuController(IMenuService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(string? search)
        {
            MenuVM menu = await _service.GetAll(search);
            return View(menu);
        }
    }
}
