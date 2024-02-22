using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Elegencia.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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
      
    }
}
