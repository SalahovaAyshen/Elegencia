using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(string? search)
        {
            BasketVM basketVM = await _basketService.GetAll(search);
            return View(basketVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreMeal(int id)
        {
            await _basketService.RestoreMeal(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            await _basketService.DeleteMeal(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreSalad(int id)
        {
            await _basketService.RestoreSalad(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteSalad(int id)
        {
            await _basketService.DeleteSalad(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreDessert(int id)
        {
            await _basketService.RestoreDessert(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteDessert(int id)
        {
            await _basketService.DeleteDessert(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreDrink(int id)
        {
            await _basketService.RestoreDrink(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteDrink(int id)
        {
            await _basketService.DeleteDrink(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreChef(int id)
        {
            await _basketService.RestoreChef(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteChef(int id)
        {
            await _basketService.DeleteChef(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreNews(int id)
        {
            await _basketService.RestoreNews(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteNews(int id)
        {
            await _basketService.DeleteNews(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreCategory(int id)
        {
            await _basketService.RestoreCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _basketService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreDessertCategory(int id)
        {
            await _basketService.RestoreDessertCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteDessertCategory(int id)
        {
            await _basketService.DeleteDessertCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestoreDrinkCategory(int id)
        {
            await _basketService.RestoreDrinkCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeleteDrinkCategory(int id)
        {
            await _basketService.DeleteDrinkCategory(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> RestorePosition(int id)
        {
            await _basketService.RestorePosition(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> DeletePosition(int id)
        {
            await _basketService.DeletePosition(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
