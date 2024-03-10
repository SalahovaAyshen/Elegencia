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
    public interface IFamousService
    {
        Task<IQueryable<Famous>> GetAll();
        Task<bool> PostCreate(CreateFamousVM famousVM, ModelStateDictionary modelState);
        Task Delete(int id);
    }
}
