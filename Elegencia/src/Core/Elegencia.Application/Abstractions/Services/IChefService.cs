using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services
{
    public interface IChefService
    {
        Task<ChefVM> GetAll();
        Task<Chef> GetInfo(int id);
    }
}
