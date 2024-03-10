using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    internal class ChefService : IChefService
    {
        private readonly IChefRepository _repository;

        public ChefService(IChefRepository repository)
        {
            _repository = repository;
        }
        public async Task<ChefVM> GetAll()
        {
            ICollection<Chef> chefs = await _repository.GetAllWithOrder(expression: m => m.IsDeleted == false,includes: nameof(Chef.Position)).ToListAsync();
            ChefVM chefVM = new ChefVM
            {
                Chefs = chefs,
            };
            return chefVM;
        }

        public async Task<Chef> GetInfo(int id)
        {
            if (id <= 0) throw new Exception("Bad request"); 
            Chef chef = await _repository.GetByIdAsync(id, includes: nameof(Chef.Position));
            if (chef == null) throw new Exception("Not found chef id");
            return chef;
        }
    }
}
