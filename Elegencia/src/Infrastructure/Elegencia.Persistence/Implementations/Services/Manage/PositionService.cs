using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public PositionService(IPositionRepository positionRepository, IHttpContextAccessor http, IAccountService user)
        {
            _positionRepository = positionRepository;
            _http = http;
            _user = user;
        }
        public async Task<PaginationVM<Position>> GetAll(int page, int take)
        {
            PaginationVM<Position> paginationVM = await _positionRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take);
            return paginationVM;
        }
        public async Task<bool> PostCreate(CreatePositionVM positionVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            if (await _positionRepository.GetAll().AnyAsync(c => c.Name.ToLower() == positionVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The position name is existed");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            await _positionRepository.AddAsync(new Position 
            { 
                Name = positionVM.Name,
                CreatedBy = user.Name + " " + user.Surname,
                CreatedAt = DateTime.Now
            });
            await _positionRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdatePositionVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Position position = await _positionRepository.GetByIdAsync(id);
            if (position is null) throw new NotFoundException("Not found id");
            UpdatePositionVM updatePositionVM = new UpdatePositionVM
            { Name = position.Name };
            return updatePositionVM;
        }
        public async Task<bool> PostUpdate(int id, UpdatePositionVM positionVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Position existed = await _positionRepository.GetByIdAsync(id);
            if (existed is null) throw new NotFoundException("Not found id");
            if (!modelState.IsValid) return false;
            if (await _positionRepository.GetAll().AnyAsync(c => c.Name.ToLower() == positionVM.Name.ToLower() && c.Id != id))
            {
                modelState.AddModelError("Name", "The category name is existed");
                return false;
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            existed.Name = positionVM.Name;
            existed.ModifiedAt = DateTime.Now;
            existed.ModifiedBy = user.Name + " " + user.Surname;
            _positionRepository.Update(existed);
            await _positionRepository.SaveChangesAsync();
            return true;
        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Position position = await _positionRepository.GetByIdAsync(id);
            if (position == null) throw new NotFoundException("Not found id");
            position.IsDeleted = true;
            await _positionRepository.SaveChangesAsync();
        }
    }
}
