using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    internal class HomeService : IHomeService
    {
        private readonly IMealRepository _repository;

        public HomeService(IMealRepository repository)
        {
            _repository = repository;
        }
        public async Task<HomeVM> GetAll()
        {
            ICollection<Meal> meals = await _repository.GetAllWithOrder(orderExpression: m=>m.Id).Take(4)
                .Include(m=>m.MealImages.Where(mi=>mi.IsPrimary==true))
                .Include(m=>m.Category).ToListAsync();
            HomeVM home = new HomeVM
            {
                Meals = meals
            };
            return home;
        }
    }
}
