using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Category:BaseNameableEntity
    {
        public List<Meal>? Meals { get; set; }
        public List<Salad>? Salads { get; set; }
    }
}
