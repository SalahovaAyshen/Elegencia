using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
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
    public class DrinkCategoryService : IDrinkCategoryService
    {
        private readonly IDrinkCategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public DrinkCategoryService(IDrinkCategoryRepository categoryRepository,IHttpContextAccessor http, IAccountService user)
        {
           _categoryRepository = categoryRepository;
           _http = http;
           _user = user;
        }
       
        public async Task<PaginationVM<DrinkCategory>> GetAll(int page, int take)
        {
            PaginationVM<DrinkCategory> paginationVM = await _categoryRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return paginationVM;
        }
        public async Task<bool> PostCreate(CreateDrinkCategoryVM categoryVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            if (await _categoryRepository.GetAll().AnyAsync(c => c.Name.ToLower() == categoryVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The category name is existed");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            await _categoryRepository.AddAsync(new DrinkCategory 
            { 
                Name = categoryVM.Name,
                CreatedBy = user.Name + " " + user.Surname,
                CreatedAt = DateTime.Now
            });
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdateDrinkCategoryVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DrinkCategory drinkCategory = await _categoryRepository.GetByIdAsync(id);
            if (drinkCategory is null) throw new NotFoundException("Not found id");
            UpdateDrinkCategoryVM updateDessertCategoryVM = new UpdateDrinkCategoryVM
            { Name = drinkCategory.Name };
            return updateDessertCategoryVM;
        }
        public async Task<bool> PostUpdate(int id, UpdateDrinkCategoryVM categoryVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DrinkCategory existed = await _categoryRepository.GetByIdAsync(id);
            if (existed is null) throw new NotFoundException("Not found id");
            if (!modelState.IsValid) return false;
            if (await _categoryRepository.GetAll().AnyAsync(c => c.Name.ToLower() == categoryVM.Name.ToLower() && c.Id != id))
            {
                modelState.AddModelError("Name", "The category name is existed");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            existed.Name = categoryVM.Name;
            existed.ModifiedAt = DateTime.Now;
            existed.ModifiedBy = user.Name + " " + user.Surname;
            _categoryRepository.Update(existed);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DrinkCategory category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException("Not found id");
            category.IsDeleted = true;
            await _categoryRepository.SaveChangesAsync();
        }

    }
}
