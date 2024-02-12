using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.Manage
{
    public interface IChefService
    {
        Task<PaginationVM<Chef>> GetAll(int page, int take);
        Task<CreateChefVM> GetCreate();
    }
}
