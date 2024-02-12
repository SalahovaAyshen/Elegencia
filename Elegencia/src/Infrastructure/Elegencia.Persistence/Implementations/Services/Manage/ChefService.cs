using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class ChefService : Application.Abstractions.Services.Manage.IChefService
    {
        private readonly IChefRepository _chefRepository;

        public ChefService(IChefRepository chefRepository)
        {
            _chefRepository = chefRepository;
        }
        public async Task<PaginationVM<Chef>> GetAll(int page, int take)
        {
            PaginationVM<Chef> chefs = await _chefRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take, includes: nameof(Chef.Position));
            return chefs;
        }

        public Task<CreateChefVM> GetCreate()
        {
            throw new NotImplementedException();
        }
    }
}
