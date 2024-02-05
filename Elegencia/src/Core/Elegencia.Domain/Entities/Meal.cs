using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Meal:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public string Ingredients { get; set; } = null!;

        //Relational properties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<MealImages>? MealImages { get; set; }

    }
}
