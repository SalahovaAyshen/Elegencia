using Elegencia.Application.ViewModels.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.Manage
{
    public interface IBasketService
    {
        Task<BasketVM> GetAll(string? search);
    }
}
