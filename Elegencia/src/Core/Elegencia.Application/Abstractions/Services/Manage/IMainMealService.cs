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
    public interface IMainMealService
    {
        Task<PaginationVM<Meal>> GetAll( int page, int take);
        Task<CreateMainMealVM> GetCreate();
        Task<bool> PostCreate(CreateMainMealVM mealVM, ModelStateDictionary modelState);
        Task<UpdateMainMealVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateMainMealVM mealVM, ModelStateDictionary modelState);
        Task Delete(int id);
        Task<Meal> Detail(int id);

    }
}
