using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
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

        public MainMealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }
        public async Task<PaginationVM<Meal>> GetAll(int page, int take)
        {
            PaginationVM<Meal> meals = await _mealRepository.GetAllPagination(page: page, take: take, includes:nameof(Meal.MealImages));
            return meals;

        }
    }
}
