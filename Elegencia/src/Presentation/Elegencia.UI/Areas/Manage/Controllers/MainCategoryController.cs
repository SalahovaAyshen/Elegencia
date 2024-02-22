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
    public class MainCategoryController : Controller
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<Category> paginationVM = await _mainCategoryService.GetAll(page: page, take: 6);
            return View(paginationVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMainCategoryVM categoryVM)
        {
           if(await _mainCategoryService.PostCreate(categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateMainCategoryVM categoryVM = await _mainCategoryService.GetUpdate(id);
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateMainCategoryVM categoryVM)
        {
            if (await _mainCategoryService.PostUpdate(id,categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _mainCategoryService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted \r\n</div>";
            return RedirectToAction(nameof(Index));
        }
    }
}
