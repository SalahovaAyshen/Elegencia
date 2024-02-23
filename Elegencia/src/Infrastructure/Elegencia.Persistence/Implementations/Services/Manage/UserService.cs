using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
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

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class UserService : Application.Abstractions.Services.Manage.IUserService
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

   

        public async Task<AppUser> Get()
        {
            AppUser user = await _service.GetUser(_http.HttpContext.User.Identity.Name);
           
            return user;
        }

        public async Task<UserVM> GetUser()
        {
            AppUser user = await _service.GetUser(_http.HttpContext.User.Identity.Name);
            UserVM userVM = new UserVM 
            { 
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName,
                Email = user.Email,
                Image= user.Image
            };
            return userVM;
        }

        public async Task<bool> UpdateUser(UserVM user, ModelStateDictionary modelState)
        {
            AppUser appUser = await _service.GetUser(_http.HttpContext.User.Identity.Name);
            user.Image = appUser.Image;
            user.Username = appUser.UserName;
            if (!modelState.IsValid) return false;
            string email = user.Email;
            Regex regex = new Regex(@"^(([0-9a-z]|[a-z0-9(\.)?a-z]|[a-z0-9])){1,}(\@)[a-z((\-)?)]{1,}(\.)([a-z]{1,}(\.))?([a-z]{2,3})$");
            if (!regex.IsMatch(email))
            {
                modelState.AddModelError("Email", "The wrong structure");
                return false;
            }
            if (user.Photo is not null)
            {
                if (!user.Photo.ValidateType("image/"))
                {
                    modelState.AddModelError("Photo", "The image type should be img");
                    return false;
                }
                if (!user.Photo.VaidateSize(500))
                {
                    modelState.AddModelError("Photo", "The image size is too large");
                    return false;
                }
                appUser.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                appUser.Image = await user.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            appUser.Name = user.Name;
            appUser.Surname = user.Surname;
            appUser.Email = email;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeletePhoto()
        {
            AppUser appUser = await _service.GetUser(_http.HttpContext.User.Identity.Name);
            appUser.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            appUser.Image = "user-image.jpg";
            await _context.SaveChangesAsync();
        }
    }
}
