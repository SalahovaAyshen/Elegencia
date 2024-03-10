using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.MailService;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Contexts;
using Elegencia.Persistence.Implementations.Repositories;
using Elegencia.Persistence.Implementations.Services;
using Elegencia.Persistence.Implementations.Services.MailService;
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
using ReservationService = Elegencia.Persistence.Implementations.Services.Manage.ReservationService;
namespace Elegencia.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789_.";
                options.User.RequireUniqueEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

                //options.SignIn.RequireConfirmedEmail = true;
            }

            ).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<ISaladRepository, SaladRepository>();
            services.AddScoped<IDessertRepository, DessertRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IChefRepository, ChefRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IDessertCategoryRepository, DessertCategoryRepository>();
            services.AddScoped<IDrinkCategoryRepository, DrinkCategoryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IFamousRepository, FamousRepository>();


            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<LayoutService>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<Application.Abstractions.Services.IChefService, Implementations.Services.ChefService>();
            services.AddScoped<IMainMealService, MainMealService>();
            services.AddScoped<ISaladService, SaladService>();
            services.AddScoped<IDessertService, DessertService>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IMainCategoryService, MainCategoryService>();
            services.AddScoped<IDessertCategoryService, DessertCategoryService>();
            services.AddScoped<IDrinkCategoryService, DrinkCategoryService>();
            services.AddScoped<Application.Abstractions.Services.Manage.IChefService, Implementations.Services.Manage.ChefService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<Application.Abstractions.Services.INewsService, Implementations.Services.NewsService>();
            services.AddScoped<Application.Abstractions.Services.Manage.INewsService, Implementations.Services.Manage.NewsService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<Application.Abstractions.Services.IReservationService, Implementations.Services.ReservationService>();
            services.AddScoped<Application.Abstractions.Services.Manage.IUserService, Implementations.Services.Manage.UserService>();
            services.AddScoped<Implementations.Services.Manage.UserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<Application.Abstractions.Services.Manage.IReservationService, Implementations.Services.Manage.ReservationService>();
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<Application.Abstractions.Services.IUserService, Implementations.Services.UserService>();
            services.AddScoped<IFamousService, FamousService>();

            services.AddScoped<AppDbContextInitializer>();
            return services;
        }
    }
}
