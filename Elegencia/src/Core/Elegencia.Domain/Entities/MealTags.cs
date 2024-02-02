using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class MealTags:BaseEntity
    {
        //Relational properties
        public int MealId { get; set; }
        public Meal Meal { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
