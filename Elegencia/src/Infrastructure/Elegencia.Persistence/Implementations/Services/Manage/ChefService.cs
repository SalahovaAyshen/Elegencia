using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels;
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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class ChefService : Application.Abstractions.Services.Manage.IChefService
    {
        private readonly IChefRepository _chefRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public ChefService(IChefRepository chefRepository,
            IPositionRepository positionRepository, 
            IWebHostEnvironment env, 
            IHttpContextAccessor http,
            IAccountService user)
        {
            _chefRepository = chefRepository;
            _positionRepository = positionRepository;
            _env = env;
            _http = http;
            _user = user;
        }

       

        public async Task<PaginationVM<Chef>> GetAll(int page, int take)
        {
            PaginationVM<Chef> chefs = await _chefRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take, includes: nameof(Chef.Position));
            return chefs;
        }

        public async Task<CreateChefVM> GetCreate()
        {
           CreateChefVM chefVM = new CreateChefVM();
           chefVM.Positions = await _positionRepository.GetAll().ToListAsync();
            return chefVM;
        }

       

        public async Task<bool> PostCreate(CreateChefVM chefVM, ModelStateDictionary modelState)
        {
            chefVM.Positions = await _positionRepository.GetAll().ToListAsync();
            if (!modelState.IsValid) return false;
            if (!await _positionRepository.GetAll().AnyAsync(c => c.Id == chefVM.PositionId))
            {
                modelState.AddModelError("PositionId", "Wrong position id");
                return false;
            }
            if (!chefVM.Photo.ValidateType("image/"))
            {
                modelState.AddModelError("Photo", "The image type should be img");
                return false;
            }
            if (!chefVM.Photo.VaidateSize(500))
            {
                modelState.AddModelError("Photo", "The image size is too large");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            await _chefRepository.AddAsync(new Chef
            {
                Name = chefVM.Name,
                Surname = chefVM.Surname,
                Info = chefVM.Info,
                Facebook = chefVM.Facebook,
                Instagram = chefVM.Instagram,
                Linkedin = chefVM.Linkedin,
                PositionId = chefVM.PositionId,
                Image = await chefVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                CreatedBy = user.Name + " " + user.Surname,
                CreatedAt = DateTime.Now,
            });
            await _chefRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdateChefVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id, includes: nameof(Chef.Position));
            if (chef == null) throw new NotFoundException("Not found id");
            UpdateChefVM updateChefVM = new UpdateChefVM
            {
                Name = chef.Name,
                Surname = chef.Surname,
                Info = chef.Info,
                PositionId = chef.PositionId,
                Positions = await _positionRepository.GetAll().ToListAsync(),
                Facebook = chef.Facebook,
                Instagram = chef.Instagram,
                Linkedin = chef.Linkedin,
                Image = chef.Image,
            };
            return updateChefVM;
        }
        public async Task<bool> PostUpdate(int id, UpdateChefVM chefVM, ModelStateDictionary modelState)
        {
            chefVM.Positions = await _positionRepository.GetAll().ToListAsync();
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id, includes: nameof(Chef.Position));
            if (chef == null) throw new NotFoundException("Not found id");
            chefVM.Image = chef.Image;
            if (!modelState.IsValid) return false;
            if (!await _positionRepository.GetAll().AnyAsync(c => c.Id == chefVM.PositionId))
            {
                modelState.AddModelError("PositionId", "Wrong position id");
                return false;
            }
            if(chefVM.Photo is not null)
            {
                if (!chefVM.Photo.ValidateType("image/"))
                {
                    modelState.AddModelError("Photo", "The image type should be img");
                    return false;
                }
                if (!chefVM.Photo.VaidateSize(500))
                {
                    modelState.AddModelError("Photo", "The image size is too large");
                    return false;
                }
                chef.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                chef.Image = await chefVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            chef.Name = chefVM.Name;
            chef.Surname = chefVM.Surname;
            chef.Facebook = chefVM.Facebook;
            chef.Info = chefVM.Info;
            chef.Instagram = chefVM.Instagram;
            chef.Linkedin = chefVM.Linkedin;
            chef.PositionId = chefVM.PositionId;
            chef.ModifiedAt = DateTime.Now;
            chef.ModifiedBy = user.Name + " " + user.Surname;
            await _chefRepository.SaveChangesAsync();
            return true;

        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id);
            if (chef is null) throw new NotFoundException("Not found id");
            chef.IsDeleted = true;
            await _chefRepository.SaveChangesAsync();
        }

        public async Task<Chef> Detail(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id, includes: new string[] { nameof(Chef.Position) });
            if (chef is null) throw new NotFoundException("Not found id");
            return chef;
        }
    }
}
