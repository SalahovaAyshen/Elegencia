using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _service;
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public UserService(IHttpContextAccessor http, IAccountService service, IWebHostEnvironment env, AppDbContext context)
        {
            _http = http;
            _service = service;
            _env = env;
            _context = context;
        }
        public async Task<MemberVM> GetUser()
        {
            AppUser user = await _service.GetUser(_http.HttpContext.User.Identity.Name);
            MemberVM userVM = new MemberVM
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email
            };
            return userVM;
        }

        public async Task<bool> UpdateUser(MemberVM user, ModelStateDictionary modelState)
        {
            AppUser appUser = await _service.GetUser(_http.HttpContext.User.Identity.Name);
            if (!modelState.IsValid) return false;
            string email = user.Email;
            Regex regex = new Regex(@"^(([0-9a-z]|[a-z0-9(\.)?a-z]|[a-z0-9])){1,}(\@)[a-z((\-)?)]{1,}(\.)([a-z]{1,}(\.))?([a-z]{2,3})$");
            if (!regex.IsMatch(email))
            {
                modelState.AddModelError("Email", "The wrong structure");
                return false;
            }
            appUser.Name = user.Name;
            appUser.Surname = user.Surname;
            appUser.Email = email;
            appUser.UserName = user.Username;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
