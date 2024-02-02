using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class DrinkCategory:BaseNameableEntity
    {
        //Relational properties
        public List<Drink>? Drinks { get; set; }
    }
}
