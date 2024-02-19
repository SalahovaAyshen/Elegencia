using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Validators.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public BasketService(IMealRepository mealRepository, 
            ISaladRepository saladRepository,
            IDessertRepository dessertRepository,
            IDrinkRepository drinkRepository,
            ICategoryRepository categoryRepository,
            IDessertCategoryRepository dessertCategoryRepository,
            IDrinkCategoryRepository drinkCategoryRepository,
            IChefRepository chefRepository,
            IPositionRepository positionRepository,
            INewsRepository newsRepository)
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
    }
}
