using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page=1)
        {
          
           PaginationVM<Meal> mainMeal = await _mainMealService.GetAll(page, take:3);
            return View(mainMeal);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
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
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {mealVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(mealVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
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
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {mealVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(mealVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _mainMealService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted \r\n</div>";
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Detail(int id)
        {
            Meal meal = await _mainMealService.Detail(id);
            return View(meal);
        }
    }
}
