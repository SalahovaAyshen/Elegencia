using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page=1)
        {
            PaginationVM<Salad> paginationVM = await _saladService.GetAll(page:page, take:3);
            return View(paginationVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Create()
        {
            CreateSaladVM createSaladVM = await _saladService.GetCreate();
            return View(createSaladVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSaladVM saladVM)
        {
            if (await _saladService.PostCreate(saladVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {saladVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(saladVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateSaladVM updateSaladVM = await _saladService.GetUpdate(id);
            return View(updateSaladVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateSaladVM saladVM)
        {
            if (await _saladService.PostUpdate(id, saladVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {saladVM.Name}\r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(saladVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _saladService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Detail(int id)
        {
            Salad salad = await _saladService.Detail(id);
            return View(salad);
        }
    }
}
