using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class BasketVM
    {
        public IQueryable<Meal> Meals { get; set; }
        public IQueryable<Salad> Salads { get; set; }
        public IQueryable<Dessert> Desserts { get; set; }
        public IQueryable<Drink> Drinks { get; set; }
        public IQueryable<Category> MainCategories { get; set; }
    }
}
