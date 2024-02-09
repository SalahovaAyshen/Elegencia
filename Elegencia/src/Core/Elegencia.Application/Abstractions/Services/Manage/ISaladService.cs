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
    public interface ISaladService
    {
        Task<PaginationVM<Salad>> GetAll(int page, int take);
        Task<CreateSaladVM> GetCreate();
        Task<bool> PostCreate(CreateSaladVM saladVM, ModelStateDictionary modelState);
        Task<UpdateSaladVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateSaladVM saladVM, ModelStateDictionary modelState);
        Task Delete(int id);
        Task<Salad> Detail(int id);
    }
}
