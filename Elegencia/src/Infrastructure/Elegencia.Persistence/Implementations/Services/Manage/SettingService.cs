using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
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
    public class SettingService : ISettingService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public SettingService(AppDbContext context, IHttpContextAccessor http, IAccountService user)
        {
            _context = context;
            _http = http;
            _user = user;
        }


        public async Task<ICollection<Setting>> GetAll()
        {
            ICollection<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }

        public async Task<UpdateSettingVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s=>s.Id== id);
            if (setting == null) throw new NotFoundException("Not found id");
            UpdateSettingVM settingVM = new UpdateSettingVM
            {
                Value = setting.Value,
            };
            return settingVM;
        }

        public async Task<bool> UpdatePost(int id, UpdateSettingVM settingVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (setting == null) throw new NotFoundException("Not found id");
            if (!modelState.IsValid) return false;
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            setting.Value = settingVM.Value;
            setting.ModifiedAt = DateTime.Now;
            setting.ModifiedBy = user.Name + " " + user.Surname;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
