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
    public interface IDrinkService
    {
        Task<PaginationVM<Drink>> GetAll(int page, int take);
        Task<CreateDrinkVM> GetCreate();
        Task<bool> PostCreate(CreateDrinkVM drinkVM, ModelStateDictionary modelState);
        Task<UpdateDrinkVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateDrinkVM drinkVM, ModelStateDictionary modelState);
        Task Delete(int id);
        Task<Drink> Detail(int id);
    }
}
