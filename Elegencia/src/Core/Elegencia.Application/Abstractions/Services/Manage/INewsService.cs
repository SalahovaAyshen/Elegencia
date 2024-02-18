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
    public interface INewsService
    {
        Task<ICollection<News>> GetAll();
        Task<bool> CreatePost(CreateNewsVM newsVM, ModelStateDictionary modelState);
        Task<UpdateNewsVM> GetUpdate(int id);
        Task<bool> PostUpdate(int id, UpdateNewsVM updateVM, ModelStateDictionary modelState);
        Task Delete(int id);
        
    }
}
