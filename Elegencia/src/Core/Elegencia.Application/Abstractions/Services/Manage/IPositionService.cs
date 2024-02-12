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
    public interface IPositionService
    {
        Task<PaginationVM<Position>> GetAll(int page, int take);
        Task<bool> PostCreate(CreatePositionVM positionVM, ModelStateDictionary modelState);
        Task<UpdatePositionVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdatePositionVM positionVM, ModelStateDictionary modelState);
        Task Delete(int id);
    }
}
