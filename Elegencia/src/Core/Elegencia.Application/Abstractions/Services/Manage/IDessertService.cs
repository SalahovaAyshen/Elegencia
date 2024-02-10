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
    public interface IDessertService
    {
        Task<PaginationVM<Dessert>> GetAll(int page, int take);
        Task<CreateDessertVM> GetCreate();
        Task<bool> PostCreate(CreateDessertVM dessertVM, ModelStateDictionary modelState);
        Task<UpdateDessertVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateDessertVM dessertVM, ModelStateDictionary modelState);
        Task Delete(int id);
        Task<Dessert> Detail(int id);
    }
}
