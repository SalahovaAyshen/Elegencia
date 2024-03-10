using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> UserSettings()
        {
            MemberVM user = await _userService.GetUser();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UserSettings(MemberVM user)
        {
            if (await _userService.UpdateUser(user, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-secondary\" role=\"alert\">\r\n Your profile successfully updated \r\n</div>";
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
