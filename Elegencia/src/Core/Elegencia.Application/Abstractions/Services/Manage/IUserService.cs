using Elegencia.Application.ViewModels;
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
    public interface IUserService
    {
        Task<AppUser> Get();
        Task<UserVM> GetUser();
        Task<bool> UpdateUser(UserVM user, ModelStateDictionary modelState);
        Task DeletePhoto();

    }
}
