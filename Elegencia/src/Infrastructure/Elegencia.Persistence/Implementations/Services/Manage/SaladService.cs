using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICategoryRepository _categoryRepository;

        public SaladService(ISaladRepository saladRepository, ICategoryRepository categoryRepository)
        {
            _saladRepository = saladRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<PaginationVM<Salad>> GetAll(int page, int take)
        {
            PaginationVM<Salad> salads = await _saladRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return salads;
        }

        public async Task<CreateSaladVM> GetCreate()
        {
            CreateSaladVM createSaladVM = new CreateSaladVM();
            createSaladVM.Categories = await _categoryRepository.GetAll().ToListAsync();
            return createSaladVM;
        }
    }
}
