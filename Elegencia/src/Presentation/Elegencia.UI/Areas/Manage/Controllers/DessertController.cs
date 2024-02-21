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
    public class DessertController : Controller
    {
        private readonly IDessertService _dessertService;

        public DessertController(IDessertService dessertService)
        {
            _dessertService = dessertService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<Dessert> pagination = await _dessertService.GetAll(page: page, take: 3);
            return View(pagination);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Create()
        {
            CreateDessertVM createDessertVM = await _dessertService.GetCreate();
            return View(createDessertVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDessertVM dessertVM)
        {
            if (await _dessertService.PostCreate(dessertVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {dessertVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(dessertVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateDessertVM dessert = await _dessertService.GetUpdate(id);
            return View(dessert);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateDessertVM dessertVM)
        {
            if (await _dessertService.PostUpdate(id, dessertVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {dessertVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(dessertVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _dessertService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted \r\n</div>";
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Detail(int id)
        {
            Dessert dessert = await _dessertService.Detail(id);
            return View(dessert);
        }
    }
}
