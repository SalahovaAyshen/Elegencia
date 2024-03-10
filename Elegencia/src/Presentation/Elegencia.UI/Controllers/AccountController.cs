using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.MailService;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Elegencia.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;

        public AccountController(IAccountService accountService, UserManager<AppUser> userManager, IMailService mailService )
        {
            _accountService = accountService;
            _userManager = userManager;
            _mailService = mailService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if(await _accountService.Register(registerVM, ModelState))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnurl)
        {
            if (await _accountService.Login(loginVM, ModelState))
            {
                if(returnurl== null)
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(returnurl);
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home", new { area = ""});
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordvm)
        {
            if (!ModelState.IsValid) return View(forgotPasswordvm);
            AppUser user = await _userManager.FindByEmailAsync(forgotPasswordvm.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User Not Found");
                return View(forgotPasswordvm);
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string link = Url.Action("ResetPassword", "Account", new { userId = user.Id, token = token }, HttpContext.Request.Scheme);
            await _mailService.SendEmailAsync(user.Email, "Reset Password", $"<body style=\"margin: 0; padding: 0; background-color: #05161A;\">\n    <div class=\"email-wrapper\" style=\"display: flex; justify-content: center; align-items: center;flex-direction: column; margin-top: 50px;\">\n        <div class=\"email\" style=\"padding: 50px; color: white; border-radius: 16px; border: 1px dashed #ffd28d;\">\n            <h1 style=\"text-align: center; margin-top:0; margin-bottom: 10px;\">Welocome, to <i style=\"color: #ffd28d\">Elegencia</i> !</h1>\n            <h4 style=\"text-align: center;\">Thank you for joining us !</h4>\n\n            <div class=\"btn-wrapper\" style=\"display: flex; justify-content: center; align-items: center; margin-top: 50px;\">\n                <a href='{link}' style=\"display: flex; justify-content: center; align-items: center; flex-direction: column; background-color: transparent; border: 0.5px solid #ffd28d; color: white; padding: 10px 18px; border-radius: 8px; cursor: pointer;\">click to verify!</a>\n            </div>\n        </div>\n\n        <div class=\"image-wrapper\" style=\"border-radius: 8px; display: flex; justify-content: center; align-items: center; width: 675px; height: 333px; overflow: hidden; border-radius: 16px; margin-top: 50px;\">\n            <img style=\"object-fit: cover; object-position: center; display: flex; justify-content: center;\" src=\"https://images.pexels.com/photos/260922/pexels-photo-260922.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\" alt=\"\">\n        </div>\n    </div>\n</body>", true);

            return RedirectToAction(nameof(Login));
        }
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException("Token or UserId is null");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new ArgumentNullException("User is null");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM vm, string userId, string token)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(token)) throw new ArgumentNullException("Token or UserId is null");
            if (!ModelState.IsValid) return View(vm);
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) throw new ArgumentNullException("User is null");
            var identityUser = await _userManager.ResetPasswordAsync(user, token, vm.NewPassword);
            return RedirectToAction(nameof(Login));
        }
    }
}

