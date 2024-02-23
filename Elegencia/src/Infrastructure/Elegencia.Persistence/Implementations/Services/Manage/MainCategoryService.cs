using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
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
    public class MainCategoryService : IMainCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public MainCategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor http, IAccountService user)
        {
            _categoryRepository = categoryRepository;
            _http = http;
            _user = user;
        }
        public async Task<PaginationVM<Category>> GetAll(int page, int take)
        {
            PaginationVM<Category> paginationVM = await _categoryRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return paginationVM;
        }

        

        public async Task<bool> PostCreate(CreateMainCategoryVM categoryVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            if (await _categoryRepository.GetAll().AnyAsync(c => c.Name.ToLower() == categoryVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The category name is existed");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            await _categoryRepository.AddAsync(new Category 
            {
                Name = categoryVM.Name,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname
            });
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdateMainCategoryVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Category category = await _categoryRepository.GetByIdAsync(id);
            if(category==null) throw new NotFoundException("Not found id");
            UpdateMainCategoryVM categoryVM = new UpdateMainCategoryVM
            {
                Name = category.Name,
            };
            return categoryVM;
        }
        public async Task<bool> PostUpdate(int id, UpdateMainCategoryVM categoryVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Category existed = await _categoryRepository.GetByIdAsync(id);
            if (existed == null) throw new NotFoundException("Not found id");
            if (!modelState.IsValid) return false;
            if (await _categoryRepository.GetAll().AnyAsync(c => c.Name.ToLower() == categoryVM.Name.ToLower() && c.Id!=id))
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
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException("Not found id");
            category.IsDeleted = true;
            await _categoryRepository.SaveChangesAsync();
        }
    }
}
