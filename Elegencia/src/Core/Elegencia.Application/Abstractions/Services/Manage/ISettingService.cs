
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
    public interface ISettingService
    {
        Task<ICollection<Setting>> GetAll();
        Task<UpdateSettingVM> GetUpdate(int id);
        Task<bool> UpdatePost(int id, UpdateSettingVM settingVM, ModelStateDictionary modelState);
    }
}
