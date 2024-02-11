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
    public interface IDrinkCategoryService
    {
        Task<PaginationVM<DrinkCategory>> GetAll(int page, int take);
        Task<bool> PostCreate(CreateDrinkCategoryVM categoryVM, ModelStateDictionary modelState);
        Task<UpdateDrinkCategoryVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateDrinkCategoryVM categoryVM, ModelStateDictionary modelState);
        Task Delete(int id);
    }
}
