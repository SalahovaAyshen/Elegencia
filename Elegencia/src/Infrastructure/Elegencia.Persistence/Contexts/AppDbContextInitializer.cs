using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Contexts
{
    public class AppDbContextInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public AppDbContextInitializer(
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            AppDbContext context)
        {
            _roleManager = roleManager;
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
        }
        public async Task InitializeDbContext()
        {
            await _context.Database.MigrateAsync();
        }
        public async Task CreateRoleAsync()
        {
            foreach (var role in Enum.GetValues(typeof(UserRole)))
            {
                if (!await _roleManager.RoleExistsAsync(role.ToString()))
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });

            }
        }

        public async Task InitializeAdmin()
        {
            AppUser admin = new AppUser
            {
                Name = "Admin",
                Surname = "Admin",
                Email = _configuration["AdminSettings:Email"],
                UserName = _configuration["AdminSettings:Username"]
            };

            await _userManager.CreateAsync(admin, _configuration["AdminSettings:Password"]);
            await _userManager.AddToRoleAsync(admin, UserRole.Admin.ToString());
        }
    }
}
