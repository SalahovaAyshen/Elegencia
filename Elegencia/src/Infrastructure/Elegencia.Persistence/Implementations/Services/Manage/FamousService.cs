using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Elegencia.Persistence.Implementations.Services.Manage
{

    public class FamousService : IFamousService
    {
        private readonly IFamousRepository _repository;
        private readonly IAccountService _user;
        private readonly IHttpContextAccessor _http;
        private readonly IWebHostEnvironment _env;

        public FamousService(IFamousRepository repository, IAccountService user, IHttpContextAccessor http, IWebHostEnvironment env)
        {
            _repository = repository;
            _user = user;
            _http = http;
            _env = env;
        }

       
        public async Task<IQueryable<Famous>> GetAll()
        {
            IQueryable<Famous> famous =  _repository.GetAllWithOrder(expression:e=>e.IsDeleted==false);
            return famous;
        }

        public async Task<bool> PostCreate(CreateFamousVM famousVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
        
            if (!famousVM.Photo.ValidateType("image/"))
            {
                modelState.AddModelError("Image", "The image type should be img");
                return false;
            }
            if (!famousVM.Photo.VaidateSize(5000))
            {
                modelState.AddModelError("Image", "The image size is too large");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            await _repository.AddAsync(new Famous
            {
                Name = famousVM.Name,
                Surname = famousVM.Surname,
                Country = famousVM.Country,
                Opinion = famousVM.Opinion,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname,
                Image = await famousVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
            });
            await _repository.SaveChangesAsync();
            return true;
        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Famous famous = await _repository.GetByIdAsync(id);
            if (famous is null) throw new NotFoundException("Not found id");
            famous.IsDeleted = true;
            await _repository.SaveChangesAsync();
        }

    }
}
