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
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly IDrinkCategoryRepository _drinkCategoryRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public DrinkService(IDrinkRepository drinkRepository, 
            IDrinkCategoryRepository drinkCategoryRepository, 
            IWebHostEnvironment env,
            IHttpContextAccessor http,
            IAccountService user)
        {
           _drinkRepository = drinkRepository;
           _drinkCategoryRepository = drinkCategoryRepository;
           _env = env;
           _http = http;
           _user = user;
        }

       

        public async Task<PaginationVM<Drink>> GetAll(int page, int take)
        {
            PaginationVM<Drink> drinks = await _drinkRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return drinks;
        }

        public async Task<CreateDrinkVM> GetCreate()
        {
            CreateDrinkVM createDrinkVM = new CreateDrinkVM();
            createDrinkVM.DrinkCategories = await _drinkCategoryRepository.GetAll().ToListAsync();
            return createDrinkVM;
        }

      

        public async Task<bool> PostCreate(CreateDrinkVM drinkVM, ModelStateDictionary modelState)
        {
            drinkVM.DrinkCategories = _drinkCategoryRepository.GetAll().ToList();
            if (!modelState.IsValid) return false;
            if (await _drinkRepository.GetAll().AnyAsync(c => c.Name.ToLower() == drinkVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The drink name is existed");
                return false;
            }
            if (drinkVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _drinkCategoryRepository.GetAll().AnyAsync(c => c.Id == drinkVM.DrinkCategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if (!drinkVM.Photo.ValidateType("image/"))
            {
                modelState.AddModelError("Image", "The image type should be img");
                return false;
            }
            if (!drinkVM.Photo.VaidateSize(5000))
            {
                modelState.AddModelError("Image", "The image size is too large");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            await _drinkRepository.AddAsync(new Drink
            {
                Name = drinkVM.Name,
                Price = drinkVM.Price,
                DrinkCategoryId = drinkVM.DrinkCategoryId,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname,
                Image = await drinkVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative = drinkVM.Name
            });
            await _drinkRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdateDrinkVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number ");
            Drink drink = await _drinkRepository.GetByIdAsync(id, includes: nameof(Drink.DrinkCategory));
            if(drink==null) throw new NotFoundException("Not found id");
            UpdateDrinkVM updateDrinkVM = new UpdateDrinkVM
            {
                Name = drink.Name,
                Price = drink.Price,
                DrinkCategoryId = drink.DrinkCategoryId,
                DrinkCategories = await _drinkCategoryRepository.GetAll().ToListAsync(),
                Image = drink.Image,
            };
            return updateDrinkVM;
        }
        public async Task<bool> PostUpdate(int id, UpdateDrinkVM drinkVM, ModelStateDictionary modelState)
        {
            drinkVM.DrinkCategories = await _drinkCategoryRepository.GetAll().ToListAsync();
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number ");
            Drink drink = await _drinkRepository.GetByIdAsync(id, includes: nameof(Drink.DrinkCategory));
            if (drink == null) throw new NotFoundException("Not found id");
            drinkVM.Image = drink.Image;
            if (!modelState.IsValid) return false;
            if (await _drinkRepository.GetAll().AnyAsync(c => c.Name.ToLower() == drinkVM.Name.ToLower() && c.Id != id))
            {
                modelState.AddModelError("Name", "The drink name is existed");
                return false;
            }
            if (drinkVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _drinkCategoryRepository.GetAll().AnyAsync(c => c.Id == drinkVM.DrinkCategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if (drinkVM.Photo is not null)
            {
                if (!drinkVM.Photo.ValidateType("image/"))
                {
                    modelState.AddModelError("Image", "The image type should be img");
                    return false;
                }
                if (!drinkVM.Photo.VaidateSize(5000))
                {
                    modelState.AddModelError("Image", "The image size is too large");
                    return false;
                }
                drink.Image.DeleteFile(_env.WebRootPath, "assets", "manage");
                drink.Image = await drinkVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            drink.Name = drinkVM.Name;
            drink.Price = drinkVM.Price;
            drink.DrinkCategoryId = drinkVM.DrinkCategoryId;
            drink.Alternative = drinkVM.Name;
            drink.ModifiedAt = DateTime.Now;
            drink.ModifiedBy = user.Name + " " + user.Surname;
            await _drinkRepository.SaveChangesAsync();
            return true; 
        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Drink drink = await _drinkRepository.GetByIdAsync(id);
            if (drink is null) throw new NotFoundException("Not found id");
            drink.IsDeleted = true;
            await _drinkRepository.SaveChangesAsync();
        }

        public async Task<Drink> Detail(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Drink drink = await _drinkRepository.GetByIdAsync(id, includes: new string[] { nameof(Drink.DrinkCategory) });
            if (drink == null) throw new NotFoundException("Not found id");
            return drink;
        }
    }
}
