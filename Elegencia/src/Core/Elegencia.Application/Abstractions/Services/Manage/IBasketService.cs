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
        Task RestoreMeal(int id);
        Task DeleteMeal(int id);
        Task RestoreSalad(int id);
        Task DeleteSalad(int id);
        Task RestoreDessert(int id);
        Task DeleteDessert(int id);
        Task RestoreDrink(int id);
        Task DeleteDrink(int id);
        Task RestoreChef(int id);
        Task DeleteChef(int id);
        Task RestoreNews(int id);
        Task DeleteNews(int id);
        Task RestoreCategory(int id);
        Task DeleteCategory(int id);
        Task RestoreDessertCategory(int id);
        Task DeleteDessertCategory(int id);
        Task RestoreDrinkCategory(int id);
        Task DeleteDrinkCategory(int id);
        Task RestorePosition(int id);
        Task DeletePosition(int id);

    }
}
