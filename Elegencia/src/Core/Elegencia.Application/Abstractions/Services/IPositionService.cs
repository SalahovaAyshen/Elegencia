using Elegencia.Application.DTOs.Positions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services
{
    public interface IPositionService
    {
        Task<ICollection<PositionItemDto>> GetAllAsync(int page, int take);
        Task Create(PositionCreateDto dto);
    }
}
