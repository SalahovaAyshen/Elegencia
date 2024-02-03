using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class MenuVM
    {
        public ICollection<Meal> MainDishes { get; set; }
        public string? Search { get; set; }
        public ICollection<Salad> Salads { get; set; }
        public ICollection<Dessert> Desserts { get; set; }
        public ICollection<Drink> Drinks { get; set; }
    }
}
