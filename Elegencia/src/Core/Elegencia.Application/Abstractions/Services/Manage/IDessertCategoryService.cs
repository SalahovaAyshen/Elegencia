using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.Manage
{
    public interface IDessertCategoryService
    {
        Task<PaginationVM<DessertCategory>> GetAll(int page, int take);
        Task<bool> PostCreate(CreateDessertCategoryVM categoryVM, ModelStateDictionary modelState);
        Task<UpdateDessertCategoryVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateDessertCategoryVM categoryVM, ModelStateDictionary modelState);
        Task Delete(int id);
    }
}
