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
    public interface IChefService
    {
        Task<PaginationVM<Chef>> GetAll(int page, int take);
        Task<CreateChefVM> GetCreate();
        Task<bool> PostCreate(CreateChefVM chefVM, ModelStateDictionary modelState);
        Task<UpdateChefVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateChefVM chefVM, ModelStateDictionary modelState);
        Task Delete(int id);
        Task<Chef> Detail(int id);
    }
}
