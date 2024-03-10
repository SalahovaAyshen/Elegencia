using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
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
    public class MainMealService : IMainMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public MainMealService(IMealRepository mealRepository, 
            ICategoryRepository categoryRepository, 
            IWebHostEnvironment env,
            IHttpContextAccessor http,
            IAccountService user
           )
        {
            _mealRepository = mealRepository;
            _categoryRepository = categoryRepository;
            _env = env;
            _http = http;
            _user = user;
        }
        public async Task<PaginationVM<Meal>> GetAll(int page, int take)
        {
            PaginationVM<Meal> meals = await _mealRepository.GetAllPagination(expression: m=>m.IsDeleted==false,page: page, take: take, includes: nameof(Meal.MealImages));
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
            if (!mealVM.MainPhoto.VaidateSize(5000))
            {
                modelState.AddModelError("MainPhoto", "The image size is too large");
                return false;
            }
            if (!mealVM.HoverPhoto.ValidateType("image/"))
            {
                modelState.AddModelError("HoverPhoto", "The image type should be img");
                return false;
            }
            if (!mealVM.HoverPhoto.VaidateSize(5000))
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

            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            Meal meal = new Meal
            {
                Name = mealVM.Name,
                Price = mealVM.Price,
                Ingredients = mealVM.Ingredients,
                CategoryId = mealVM.CategoryId,
                MealImages = new List<MealImages> { mainPhoto, hoverPhoto },
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname
            };
            await _mealRepository.AddAsync(meal);
            await _mealRepository.SaveChangesAsync();
            return true;

        }
        public async Task<UpdateMainMealVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Meal meal = await _mealRepository.GetByIdAsync(id, includes: nameof(Meal.MealImages));
            if(meal==null) throw new NotFoundException("Not found id");
            UpdateMainMealVM updateMainMealVM = new UpdateMainMealVM
            {
                Name = meal.Name,
                Price = meal.Price,
                Ingredients = meal.Ingredients,
                CategoryId = (int)meal.CategoryId,
                Categories = await _categoryRepository.GetAll().ToListAsync(),
                MealImages = meal.MealImages,
                MainImage = meal.MealImages.FirstOrDefault(mi=>mi.IsPrimary==true)?.Image,
                HoverImage = meal.MealImages.FirstOrDefault(mi=>mi.IsPrimary==false)?.Image
            };
            return updateMainMealVM;
        }

        public async Task<bool> PostUpdate(int id, UpdateMainMealVM mealVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            mealVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            Meal existed = await _mealRepository.GetByIdAsync(id, includes: nameof(Meal.MealImages));
            if (existed == null) throw new NotFoundException("Not found id");
            mealVM.MainImage = existed.MealImages.FirstOrDefault(mi => mi.IsPrimary == true)?.Image;
            mealVM.HoverImage = existed.MealImages.FirstOrDefault(mi => mi.IsPrimary == false)?.Image;
            if (!modelState.IsValid) return false;
            if (await _mealRepository.GetAll().AnyAsync(c => c.Name.ToLower() == mealVM.Name.ToLower() && c.Id!=id))
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

            if (mealVM.MainPhoto != null)
            {
                if (!mealVM.MainPhoto.ValidateType("image/"))
                {
                    modelState.AddModelError("MainPhoto", "The entered photo type does not match the required one");
                    return false;
                }
                if (!mealVM.MainPhoto.VaidateSize(500))
                {
                    modelState.AddModelError("MainPhoto", "The size of the photo is larger than required");
                    return false;
                }
            }
            if (mealVM.HoverPhoto != null)
            {
                if (!mealVM.HoverPhoto.ValidateType("image/"))
                {
                    modelState.AddModelError("HoverPhoto", "The entered photo type does not match the required one");
                    return false;
                }
                if (!mealVM.HoverPhoto.VaidateSize(500))
                {
                    modelState.AddModelError("HoverPhoto", "The size of the photo is larger than required");
                    return false;
                }
            }
            if (mealVM.MainPhoto != null)
            {
                string main = await mealVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img");
                MealImages exImage = existed.MealImages.FirstOrDefault(pi => pi.IsPrimary == true);
                exImage.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                existed.MealImages.Remove(exImage);
                existed.MealImages.Add(new MealImages
                {
                    IsPrimary = true,
                    Image = main,
                    Alternative = mealVM.Name
                });
            }
            if (mealVM.HoverPhoto != null)
            {
                string hover = await mealVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img");
                MealImages exImage = existed.MealImages.FirstOrDefault(pi => pi.IsPrimary == false);
                exImage.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                existed.MealImages.Remove(exImage);
                existed.MealImages.Add(new MealImages
                {
                    IsPrimary = false,
                    Image = hover,
                    Alternative = mealVM.Name
                });
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            existed.Name = mealVM.Name;
            existed.Price = mealVM.Price;
            existed.Ingredients = mealVM.Ingredients;
            existed.CategoryId = mealVM.CategoryId;
            existed.ModifiedAt = DateTime.Now;
            existed.ModifiedBy = user.Name + " " + user.Surname;
             _mealRepository.Update(existed);
            await _mealRepository.SaveChangesAsync();
            return true;

        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Meal meal = await _mealRepository.GetByIdAsync(id);
            if (meal is null) throw new NotFoundException("Not found id");
            meal.IsDeleted = true;
            await _mealRepository.SaveChangesAsync();

        }
        public async Task<Meal> Detail(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Meal meal = await _mealRepository.GetByIdAsync(id, includes: new string[] { nameof(Meal.MealImages), nameof(Meal.Category) });
            if (meal is null) throw new NotFoundException("Not found id");
            return meal;
        }
    }
}
