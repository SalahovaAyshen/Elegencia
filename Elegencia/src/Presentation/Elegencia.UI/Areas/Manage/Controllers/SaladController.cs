using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SaladController : Controller
    {
        private readonly ISaladService _saladService;

        public SaladController(ISaladService saladService)
        {
            _saladService = saladService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
            PaginationVM<Salad> paginationVM = await _saladService.GetAll(page:page, take:3);
            return View(paginationVM);
        }
    }
}
