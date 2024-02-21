using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterVM registerVM, ModelStateDictionary modelState);
        Task<bool> Login(LoginVM loginVM, ModelStateDictionary modelState);
        Task Logout();
        Task<AppUser> GetUser(string username);
        Task<int> UserCount();
    }
}
