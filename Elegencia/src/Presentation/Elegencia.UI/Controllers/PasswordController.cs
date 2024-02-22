using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class PasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPassword)
        {
            if (!ModelState.IsValid) return View(forgotPassword);
            var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
            if (user is null)
            {
                ModelState.AddModelError("Email", "Not found email");
                return View(forgotPassword);
            };
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action("ResetPassword", "Password", new {userId= user.Id, token=token}, HttpContext.Request.Scheme);
            return Redirect(link);
        }
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if(string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) return BadRequest();
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return NotFound();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM passwordVM, string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) return BadRequest();
            if (!ModelState.IsValid) return View(passwordVM);
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return NotFound();
            var identityUser = await _userManager.ResetPasswordAsync(user, token, passwordVM.ConfirmPassword);
            return RedirectToAction("Login", "Account");
        }
    }
}
