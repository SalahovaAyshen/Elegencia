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
    public class ChefController : Controller
    {
        private readonly IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<Chef> paginationVM = await _chefService.GetAll(page: page, take: 3);
            return View(paginationVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Create()
        {
            CreateChefVM chefVM = await _chefService.GetCreate();
            return View(chefVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateChefVM chefVM)
        {
            if(await _chefService.PostCreate(chefVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {chefVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(chefVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateChefVM chefVM = await _chefService.GetUpdate(id);
            return View(chefVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateChefVM chefVM)
        {
            if (await _chefService.PostUpdate(id, chefVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {chefVM.Name} {chefVM.Surname} \r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(chefVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _chefService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Detail(int id)
        {
            Chef chef = await _chefService.Detail(id);
            return View(chef);
        }
    }
}
