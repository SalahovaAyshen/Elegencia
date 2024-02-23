using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.Validators.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    internal class BasketService : IBasketService
    {
        private readonly IMealRepository _mealRepository;
        private readonly ISaladRepository _saladRepository;
        private readonly IDessertRepository _dessertRepository;
        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDessertCategoryRepository _dessertCategoryRepository;
        private readonly IDrinkCategoryRepository _drinkCategoryRepository;
        private readonly IChefRepository _chefRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IWebHostEnvironment _env;

        public BasketService(IMealRepository mealRepository, 
            ISaladRepository saladRepository,
            IDessertRepository dessertRepository,
            IDrinkRepository drinkRepository,
            ICategoryRepository categoryRepository,
            IDessertCategoryRepository dessertCategoryRepository,
            IDrinkCategoryRepository drinkCategoryRepository,
            IChefRepository chefRepository,
            IPositionRepository positionRepository,
            INewsRepository newsRepository,
            IWebHostEnvironment env)
        {
            _mealRepository = mealRepository;
            _saladRepository = saladRepository;
            _dessertRepository = dessertRepository;
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
            _dessertCategoryRepository = dessertCategoryRepository;
            _drinkCategoryRepository = drinkCategoryRepository;
            _chefRepository = chefRepository;
            _positionRepository = positionRepository;
            _newsRepository = newsRepository;
            _env = env;
        }
        public async Task<BasketVM> GetAll(string? search)
        {
            IQueryable<Meal> meals = _mealRepository.GetAllWithSearch(search: search,expression: e => e.IsDeleted == true, includes: nameof(Meal.MealImages));
            IQueryable<Salad> salads = _saladRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<Dessert> desserts =  _dessertRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true, includes: nameof(Dessert.DessertImages));
            IQueryable<Drink> drinks =  _drinkRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<Category> categories =  _categoryRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<DessertCategory> dessertCategories =  _dessertCategoryRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<DrinkCategory> drinkCategories = _drinkCategoryRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<Chef> chefs =  _chefRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<Position> positions =  _positionRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);
            IQueryable<News> news =  _newsRepository.GetAllWithSearch(search: search, expression: e => e.IsDeleted == true);

            BasketVM basketVM = new BasketVM 
            { 
              Meals = meals,
              Salads = salads,
              Desserts = desserts,
              Drinks = drinks,
              MainCategories = categories,
              DessertCategories = dessertCategories,
              DrinkCategories = drinkCategories,
              Chefs = chefs,
              Positions = positions,
              News = news,
            };
            return basketVM;
        }
        public async Task RestoreMeal(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Meal meal = await _mealRepository.GetByIdAsync(id);
            if (meal is null) throw new NotFoundException("Not found id");
            meal.IsDeleted = false;
            await _mealRepository.SaveChangesAsync();
        }
        public async Task DeleteMeal(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Meal meal = await _mealRepository.GetByIdAsync(id);
            if (meal is null) throw new NotFoundException("Not found id");
            if (meal.MealImages != null)
            {
                foreach (MealImages item in meal.MealImages)
                {
                    item.Image.DeleteFile(_env.WebRootPath, "assets", "img");

                }
            }
            _mealRepository.Delete(meal);
            await _mealRepository.SaveChangesAsync();
        }
      
        public async Task RestoreSalad(int id)
        {

            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Salad salad = await _saladRepository.GetByIdAsync(id);
            if (salad is null) throw new NotFoundException("Not found id");
            salad.IsDeleted = false;
            await _saladRepository.SaveChangesAsync();
        }
        public async Task DeleteSalad(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Salad salad = await _saladRepository.GetByIdAsync(id);
            if (salad is null) throw new NotFoundException("Not found id");
            salad.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            _saladRepository.Delete(salad);
            await _saladRepository.SaveChangesAsync();
        }
        public async Task RestoreDessert(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Dessert dessert = await _dessertRepository.GetByIdAsync(id);
            if (dessert is null) throw new NotFoundException("Not found id");
            dessert.IsDeleted = false;
            await _dessertRepository.SaveChangesAsync();
        }
        public async Task DeleteDessert(int id)
        {

            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Dessert dessert = await _dessertRepository.GetByIdAsync(id);
            if (dessert is null) throw new NotFoundException("Not found id");
            if (dessert.DessertImages != null)
            {
                foreach (DessertImage item in dessert.DessertImages)
                {
                    item.Image.DeleteFile(_env.WebRootPath, "assets", "img");

                }
            }
            _dessertRepository.Delete(dessert);
            await _dessertRepository.SaveChangesAsync();

        }
        public async Task RestoreDrink(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Drink drink = await _drinkRepository.GetByIdAsync(id);
            if (drink is null) throw new NotFoundException("Not found id");
            drink.IsDeleted = false;
            await _drinkRepository.SaveChangesAsync();
        }
        public async Task DeleteDrink(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Drink drink = await _drinkRepository.GetByIdAsync(id);
            if (drink is null) throw new NotFoundException("Not found id");
            drink.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            _drinkRepository.Delete(drink);
            await _drinkRepository.SaveChangesAsync();
        }
        public async Task RestoreChef(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id);
            if (chef is null) throw new NotFoundException("Not found id");
            chef.IsDeleted = false;
            await _chefRepository.SaveChangesAsync();
        }
        public async Task DeleteChef(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Chef chef = await _chefRepository.GetByIdAsync(id);
            if (chef is null) throw new NotFoundException("Not found id");
            chef.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            _chefRepository.Delete(chef);
            await _chefRepository.SaveChangesAsync();
        }
        public async Task RestoreNews(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news is null) throw new NotFoundException("Not found id");
            news.IsDeleted = false;
            await _newsRepository.SaveChangesAsync();
        }
        public async Task DeleteNews(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news is null) throw new NotFoundException("Not found id");
            news.Image.DeleteFile(_env.WebRootPath, "assets", "img");
            _newsRepository.Delete(news);
            await _newsRepository.SaveChangesAsync();
        }
        public async Task RestoreCategory(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            category.IsDeleted = false;
            await _categoryRepository.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id)
        {

            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }
        public async Task RestoreDessertCategory(int id)
        {

            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DessertCategory category = await _dessertCategoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            category.IsDeleted = false;
            await _dessertCategoryRepository.SaveChangesAsync();

        }
        public async Task DeleteDessertCategory(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DessertCategory category = await _dessertCategoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            _dessertCategoryRepository.Delete(category);
            await _dessertCategoryRepository.SaveChangesAsync();
        }
        public async Task RestoreDrinkCategory(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DrinkCategory category = await _drinkCategoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            category.IsDeleted = false;
            await _drinkCategoryRepository.SaveChangesAsync();
        }
        public async Task DeleteDrinkCategory(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            DrinkCategory category = await _drinkCategoryRepository.GetByIdAsync(id);
            if (category is null) throw new NotFoundException("Not found id");
            _drinkCategoryRepository.Delete(category);
            await _drinkCategoryRepository.SaveChangesAsync();
        }
        public async Task RestorePosition(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Position position = await _positionRepository.GetByIdAsync(id);
            if (position is null) throw new NotFoundException("Not found id");
            position.IsDeleted = false;
            await _positionRepository.SaveChangesAsync();
        }
        public async Task DeletePosition(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Position position = await _positionRepository.GetByIdAsync(id);
            if (position is null) throw new NotFoundException("Not found id");
            _positionRepository.Delete(position);
            await _positionRepository.SaveChangesAsync();
        }



    }
}
