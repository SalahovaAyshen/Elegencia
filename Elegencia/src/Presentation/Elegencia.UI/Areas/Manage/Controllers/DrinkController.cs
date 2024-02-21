using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DrinkController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<Drink> drinks = await _drinkService.GetAll(page: page, take: 3);
            return View(drinks);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Create()
        {
            CreateDrinkVM createDrinkVM = await _drinkService.GetCreate();
            return View(createDrinkVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDrinkVM drinkVM)
        {
            if (await _drinkService.PostCreate(drinkVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {drinkVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(drinkVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateDrinkVM updateDrinkVM = await _drinkService.GetUpdate(id);
            return View(updateDrinkVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateDrinkVM drinkVM)
        {
            if (await _drinkService.PostUpdate(id, drinkVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {drinkVM.Name}\r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(drinkVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _drinkService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Detail(int id)
        {
            Drink drink = await _drinkService.Detail(id);
            return View(drink);
        }
    }
}
