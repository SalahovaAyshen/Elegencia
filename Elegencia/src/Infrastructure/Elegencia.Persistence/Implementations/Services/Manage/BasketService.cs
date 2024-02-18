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

        public BasketService(IMealRepository mealRepository, 
            ISaladRepository saladRepository,
            IDessertRepository dessertRepository,
            IDrinkRepository drinkRepository,
            ICategoryRepository categoryRepository)
        {
            _mealRepository = mealRepository;
            _saladRepository = saladRepository;
            _dessertRepository = dessertRepository;
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<BasketVM> GetAll()
        {
            IQueryable<Meal> meals = await _mealRepository.GetAllWithoutSearch(expression: e => e.IsDeleted == true, includes: nameof(Meal.MealImages));
            IQueryable<Salad> salads = await _saladRepository.GetAllWithoutSearch(expression: e => e.IsDeleted == true);
            IQueryable<Dessert> desserts = await _dessertRepository.GetAllWithoutSearch(expression: e => e.IsDeleted == true, includes: nameof(Dessert.DessertImages));
            IQueryable<Drink> drinks = await _drinkRepository.GetAllWithoutSearch(expression: e => e.IsDeleted == true);
            IQueryable<Category> categories = await _categoryRepository.GetAllWithoutSearch(expression: e => e.IsDeleted == true);
            BasketVM basketVM = new BasketVM 
            { 
              Meals = meals,
              Salads = salads,
              Desserts = desserts,
              Drinks = drinks,
              MainCategories = categories
            };
            return basketVM;
        }
    }
}
