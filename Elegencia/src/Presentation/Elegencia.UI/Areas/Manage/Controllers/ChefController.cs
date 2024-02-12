using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<Chef> paginationVM = await _chefService.GetAll(page: page, take: 3);
            return View(paginationVM);
        }
    }
}
