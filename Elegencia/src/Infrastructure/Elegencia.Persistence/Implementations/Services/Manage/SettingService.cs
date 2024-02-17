using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
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

        public SettingService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Setting>> GetAll()
        {
            ICollection<Setting> settings = await _context.Settings.ToListAsync();
            return settings;
        }

        public async Task<UpdateSettingVM> GetUpdate(int id)
        {
            if (id <= 0) throw new Exception("Id can't be zero or negative number");
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s=>s.Id== id);
            if (setting == null) throw new Exception("Id not found");
            UpdateSettingVM settingVM = new UpdateSettingVM
            {
                Value = setting.Value,
            };
            return settingVM;
        }

        public async Task<bool> UpdatePost(int id, UpdateSettingVM settingVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new Exception("Id can't be zero or negative number");
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);
            if (setting == null) throw new Exception("Id not found");
            if (!modelState.IsValid) return false;
            setting.Value = settingVM.Value;
            setting.ModifiedAt = DateTime.UtcNow;
            setting.ModifiedBy = "ayshen";
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
