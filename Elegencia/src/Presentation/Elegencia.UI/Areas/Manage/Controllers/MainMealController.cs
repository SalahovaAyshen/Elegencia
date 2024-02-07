using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
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
        public async Task<IActionResult> Create()
        {
            CreateMainMealVM createMainMealVM = await _mainMealService.GetCreate();
            return View(createMainMealVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMainMealVM mealVM)
        {
           if(await _mainMealService.PostCreate(mealVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {mealVM.Name} product\r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(mealVM);
        }
        public async Task<IActionResult> Update(int id)
        {
            UpdateMainMealVM meal = await _mainMealService.GetUpdate(id);
            return View(meal);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateMainMealVM mealVM)
        {
            if (await _mainMealService.PostUpdate(id, mealVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {mealVM.Name} product\r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(mealVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _mainMealService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted product\r\n</div>";
            return RedirectToAction(nameof(Index));
        }
    }
}
