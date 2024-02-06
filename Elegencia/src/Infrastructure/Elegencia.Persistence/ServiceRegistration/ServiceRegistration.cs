using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using Elegencia.Persistence.Implementations.Repositories;
using Elegencia.Persistence.Implementations.Services;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789_.";
                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(7);

                options.SignIn.RequireConfirmedEmail = true;
            }

            ).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<ISaladRepository, SaladRepository>();
            services.AddScoped<IDessertRepository, DessertRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IChefRepository, ChefRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<LayoutService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IChefService, ChefService>();
            services.AddScoped<IMainMealService, MainMealService>();

            return services;
        }
    }
}
