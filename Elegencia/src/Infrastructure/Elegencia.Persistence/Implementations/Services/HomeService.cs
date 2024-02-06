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
        private readonly LayoutService _service;

        public HomeService(IMealRepository repository, LayoutService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<HomeVM> GetAll()
        {
            ICollection<Meal> meals = await _repository.GetAllWithOrder(expression: m => m.IsDeleted == false, orderExpression: m=>m.Id, includes:nameof(Meal.Category)).Take(4)
                .Include(m=>m.MealImages.Where(mi=>mi.IsPrimary==true)).ToListAsync();
            Dictionary<string,string> service = await _service.GetSettingsAsync();

            HomeVM home = new HomeVM
            {
                Meals = meals,
                Service = service
            };
            return home;
        }
    }
}
