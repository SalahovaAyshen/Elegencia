using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> Register(RegisterVM registerVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            if (registerVM.Image == null)
            {
                registerVM.Image = "user-image.jpg";
            }
            string email = registerVM.Email;
            Regex regex = new Regex(@"^(([0-9a-z]|[a-z0-9(\.)?a-z]|[a-z0-9])){1,}(\@)[a-z((\-)?)]{1,}(\.)([a-z]{1,}(\.))?([a-z]{2,3})$");
            if (!regex.IsMatch(email))
            {
                modelState.AddModelError("Email", "The wrong structure");
                return false;
            }
            AppUser user = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = email,
                Image = registerVM.Image,
            };
            IdentityResult result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    modelState.AddModelError(String.Empty, item.Description);
                    return false;
                }
            }
            await _signInManager.SignInAsync(user, false);
            return true;
        }
    }
}
