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
    public interface IMainCategoryService
    {
        Task<PaginationVM<Category>> GetAll(int page, int take);
        Task<bool> PostCreate(CreateMainCategoryVM categoryVM, ModelStateDictionary modelState);
        Task<UpdateMainCategoryVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateMainCategoryVM categoryVM, ModelStateDictionary modelState);
        Task Delete(int id);
    }
}
