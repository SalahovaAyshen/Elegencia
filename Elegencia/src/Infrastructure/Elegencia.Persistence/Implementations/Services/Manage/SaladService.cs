using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
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
    public class SaladService : ISaladService
    {
        private readonly ISaladRepository _saladRepository;

        public SaladService(ISaladRepository saladRepository)
        {
            _saladRepository = saladRepository;
        }
        public async Task<PaginationVM<Salad>> GetAll(int page, int take)
        {
            PaginationVM<Salad> salads = await _saladRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return salads;
        }
    }
}
