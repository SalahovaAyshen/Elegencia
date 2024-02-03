using Elegencia.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services
{
    public interface IAboutService
    {
        Task<AboutVM> GetAll();
    }
}
