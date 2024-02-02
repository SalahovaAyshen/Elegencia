using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMealRepository _mealRepository;
        private readonly ISaladRepository _saladRepository;
        private readonly IDessertRepository _dessertRepository;
        private readonly IDrinkRepository _drinkRepository;

        public MenuService(IMealRepository mealRepository, 
            ISaladRepository saladRepository,
            IDessertRepository dessertRepository,
            IDrinkRepository drinkRepository
            )
        {
            _mealRepository = mealRepository;
            _saladRepository = saladRepository;
            _dessertRepository = dessertRepository;
            _drinkRepository = drinkRepository;
        }
        public async Task<MenuVM> GetAll()
        {
            ICollection<Meal> meals = await _mealRepository.GetAll()
                 .Include(m => m.MealImages.Where(mi => mi.IsPrimary == true))
                 .Include(m=>m.Category).ToListAsync();
            ICollection<Salad> salads = await _saladRepository.GetAll().
                Include(s=>s.Category).ToListAsync();
            ICollection<Dessert> desserts = await _dessertRepository.GetAll().
                Include(d => d.DessertImages.Where(di => di.IsPrimary==true)).
                Include(d=>d.DessertCategory).ToListAsync();
            ICollection<Drink> drinks = await _drinkRepository.GetAll().
                Include(d=>d.DrinkCategory).ToListAsync();

            MenuVM menu = new MenuVM
            {
                MainDishes = meals,
                Salads = salads,
                Desserts = desserts,
                Drinks = drinks
            };
            return menu;

        }
    }
}
