using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class MealImages:BaseEntity
    {
        public string Image { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public string Alternative { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }

    }
}
