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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class SaladService : ISaladService
    {
        private readonly ISaladRepository _saladRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public SaladService(ISaladRepository saladRepository, 
            ICategoryRepository categoryRepository, 
            IWebHostEnvironment env,
            IHttpContextAccessor http,
            IAccountService user)
        {
            _saladRepository = saladRepository;
            _categoryRepository = categoryRepository;
            _env = env;
            _http = http;
            _user = user;
        }
        public async Task<PaginationVM<Salad>> GetAll(int page, int take)
        {
            PaginationVM<Salad> salads = await _saladRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return salads;
        }

        public async Task<CreateSaladVM> GetCreate()
        {
            CreateSaladVM createSaladVM = new CreateSaladVM();
            createSaladVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            return createSaladVM;
        }

        

        public async Task<bool> PostCreate(CreateSaladVM saladVM, ModelStateDictionary modelState)
        {
            saladVM.Categories = _categoryRepository.GetAll().ToList();
            if (!modelState.IsValid) return false;
            if (await _saladRepository.GetAll().AnyAsync(c => c.Name.ToLower() == saladVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The salad name is existed");
                return false;
            }
            if (saladVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _categoryRepository.GetAll().AnyAsync(c => c.Id == saladVM.CategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if (!saladVM.Photo.ValidateType("image/"))
            {
                modelState.AddModelError("Image", "The image type should be img");
                return false;
            }
            if (!saladVM.Photo.VaidateSize(5000))
            {
                modelState.AddModelError("Image", "The image size is too large");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            await _saladRepository.AddAsync(new Salad
            {
                Name = saladVM.Name,
                Price = saladVM.Price,
                Ingredients = saladVM.Ingredients,
                CategoryId = saladVM.CategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname,
                Image = await saladVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative=saladVM.Name
            });
            await _saladRepository.SaveChangesAsync();
            return true;
        }

        public async Task<UpdateSaladVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Not found id");
            Salad salad = await _saladRepository.GetByIdAsync(id, includes: nameof(Meal.Category));
            if (salad == null) throw new NotFoundException("Not found id");
            UpdateSaladVM updateSaladVM = new UpdateSaladVM
            {
                Name = salad.Name,
                Price = salad.Price,
                Ingredients = salad.Ingredients,
                CategoryId = salad.CategoryId,
                Categories = await _categoryRepository.GetAll().ToListAsync(),
                Image = salad.Image,
            };
            return updateSaladVM;
        }

        public async Task<bool> PostUpdate(int id, UpdateSaladVM saladVM, ModelStateDictionary modelState)
        {
            saladVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            if (id <= 0) throw new WrongRequestException("Not found id");
            Salad salad = await _saladRepository.GetByIdAsync(id, includes: nameof(Meal.Category));
            if (salad == null) throw new NotFoundException("Not found id");
            saladVM.Image = salad.Image;
            if (!modelState.IsValid) return false;
            if (await _saladRepository.GetAll().AnyAsync(c => c.Name.ToLower() == saladVM.Name.ToLower() && c.Id != id))
            {
                modelState.AddModelError("Name", "The salad name is existed");
                return false;
            }
            if (saladVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _categoryRepository.GetAll().AnyAsync(c => c.Id == saladVM.CategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if(saladVM.Photo is not null)
            {
                if (!saladVM.Photo.ValidateType("image/"))
                {
                    modelState.AddModelError("Image", "The image type should be img");
                    return false;
                }
                if (!saladVM.Photo.VaidateSize(500))
                {
                    modelState.AddModelError("Image", "The image size is too large");
                    return false;
                }
                salad.Image.DeleteFile(_env.WebRootPath, "assets", "manage");
                salad.Image = await saladVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);


            salad.Name = saladVM.Name;
            salad.Price = saladVM.Price;
            salad.Ingredients  = saladVM.Ingredients;
            salad.CategoryId = saladVM.CategoryId;
            salad.Alternative = saladVM.Name;
            salad.ModifiedAt = DateTime.Now;
            salad.ModifiedBy = user.Name + " " + user.Surname;
            await _saladRepository.SaveChangesAsync();
            return true;

        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Not found id");
            Salad salad = await _saladRepository.GetByIdAsync(id, includes: nameof(Meal.Category));
            if (salad == null) throw new NotFoundException("Not found id");
            salad.IsDeleted = true;
            await _saladRepository.SaveChangesAsync();
        }

        public async Task<Salad> Detail(int id)
        {
            if (id <= 0) throw new WrongRequestException("Not found id");
            Salad salad = await _saladRepository.GetByIdAsync(id, includes: nameof(Meal.Category));
            if (salad == null) throw new NotFoundException("Not found id");
            return salad;
        }
    }
}
