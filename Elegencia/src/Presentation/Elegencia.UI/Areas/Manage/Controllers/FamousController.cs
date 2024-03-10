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
    public class FamousController : Controller
    {
        private readonly IFamousService _service;

        public FamousController(IFamousService service)
        {
           _service = service;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index()
        {
            IQueryable<Famous> famous = await _service.GetAll();
            return View(famous);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFamousVM famousVM)
        {
            if (await _service.PostCreate(famousVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {famousVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(famousVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
