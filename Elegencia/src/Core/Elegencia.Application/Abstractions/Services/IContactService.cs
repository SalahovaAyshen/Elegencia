using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services
{
    public interface IContactService
    {
        Task<bool> PostContact(ContactVM contact, ModelStateDictionary modelState);
    }
}
