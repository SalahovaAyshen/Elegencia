using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.DTOs.Positions;
using Elegencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    internal class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;

        public PositionService(IPositionRepository repository)
        {
            _repository = repository;
        }
       

        public async Task<ICollection<PositionItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Position> positions =await  _repository.GetAll(skip: (page-1)*3, take: take).ToListAsync();
            ICollection<PositionItemDto> dto = new List<PositionItemDto>();
            foreach (var position in positions)
            {
                dto.Add(new PositionItemDto(Id: position.Id, Name: position.Name));
            }
            return dto;

        }
        public async Task Create(PositionCreateDto dto)
        {
             await _repository.AddAsync(new Position
            {
                Name = dto.Name,
            });
            await _repository.SaveChangesAsync();
        }
    }
}
