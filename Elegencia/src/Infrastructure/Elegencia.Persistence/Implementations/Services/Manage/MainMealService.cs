using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class MainMealService : IMainMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;

        public MainMealService(IMealRepository mealRepository, ICategoryRepository categoryRepository, IWebHostEnvironment env)
        {
            _mealRepository = mealRepository;
            _categoryRepository = categoryRepository;
            _env = env;
        }
        public async Task<PaginationVM<Meal>> GetAll(int page, int take)
        {
            PaginationVM<Meal> meals = await _mealRepository.GetAllPagination(page: page, take: take, includes: nameof(Meal.MealImages));
            return meals;

        }

        public async Task<CreateMainMealVM> GetCreate()
        {
            CreateMainMealVM mainMealVM = new CreateMainMealVM();
            mainMealVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            return mainMealVM;
        }

        public async Task<bool> PostCreate(CreateMainMealVM mealVM, ModelStateDictionary modelState)
        {
            mealVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            if (!modelState.IsValid) return false;
            if(await _mealRepository.GetAll().AnyAsync(c=>c.Name.ToLower()==mealVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The meal name is existed");
                return false;
            }
            if (mealVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _categoryRepository.GetAll().AnyAsync(c => c.Id == mealVM.CategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if (!mealVM.MainPhoto.ValidateType("image/"))
            {
                modelState.AddModelError("MainPhoto", "The image type should be img");
                return false;
            }
            if (!mealVM.MainPhoto.VaidateSize(500))
            {
                modelState.AddModelError("MainPhoto", "The image size is too large");
                return false;
            }
            if (!mealVM.HoverPhoto.ValidateType("image/"))
            {
                modelState.AddModelError("HoverPhoto", "The image type should be img");
                return false;
            }
            if (!mealVM.HoverPhoto.VaidateSize(500))
            {
                modelState.AddModelError("HoverPhoto", "The image size is too large");
                return false;
            }
            MealImages mainPhoto = new MealImages
            {
                IsPrimary = true,
                Image = await mealVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative = mealVM.Name

            };
            MealImages hoverPhoto = new MealImages
            {
                IsPrimary = false,
                Image = await mealVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative = mealVM.Name
            };
            Meal meal = new Meal
            {
                Name = mealVM.Name,
                Price = mealVM.Price,
                Ingredients = mealVM.Ingredients,
                CategoryId = mealVM.CategoryId,
                MealImages = new List<MealImages> { mainPhoto, hoverPhoto }
            };
            await _mealRepository.AddAsync(meal);
            await _mealRepository.SaveChangesAsync();
            return true;

        }
    }
}
