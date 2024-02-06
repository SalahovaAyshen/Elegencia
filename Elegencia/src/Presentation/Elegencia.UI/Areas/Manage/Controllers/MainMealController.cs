using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MainMealController : Controller
    {
        private readonly IMainMealService _mainMealService;

        public MainMealController(IMainMealService mainMealService)
        {
            _mainMealService = mainMealService;
        }
        public async Task<IActionResult> Index(int page=1)
        {
          
           PaginationVM<Meal> mainMeal = await _mainMealService.GetAll(page, take:3);
            return View(mainMeal);
        }
    }
}
