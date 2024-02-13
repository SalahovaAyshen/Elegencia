using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
