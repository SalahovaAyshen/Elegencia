using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DrinkCategoryController : Controller
    {
        private readonly IDrinkCategoryService _drinkCategoryService;

        public DrinkCategoryController(IDrinkCategoryService drinkCategoryService)
        {
            _drinkCategoryService = drinkCategoryService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<DrinkCategory> pagination = await _drinkCategoryService.GetAll(page: page, take: 3);
            return View(pagination);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDrinkCategoryVM categoryVM)
        {
            if (await _drinkCategoryService.PostCreate(categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        public async Task<IActionResult> Update(int id)
        {
            UpdateDrinkCategoryVM categoryVM = await _drinkCategoryService.GetUpdate(id);
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateDrinkCategoryVM categoryVM)
        {
            if (await _drinkCategoryService.PostUpdate(id, categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _drinkCategoryService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted \r\n</div>";
            return RedirectToAction(nameof(Index));
        }
    }
}
