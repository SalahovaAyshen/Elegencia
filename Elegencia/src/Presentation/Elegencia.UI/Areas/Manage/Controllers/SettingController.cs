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
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Index()
        {
            ICollection<Setting> settings = await _settingService.GetAll();
            return View(settings);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateSettingVM settingVM = await _settingService.GetUpdate(id);
            return View(settingVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateSettingVM settingVM)
        {
            if (await _settingService.UpdatePost(id, settingVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {settingVM.Value}\r\n</div>";
                return RedirectToAction(nameof(Index));
            }
            return View(settingVM);
        }
    }
}
