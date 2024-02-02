using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Drink:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Alternative { get; set; }
        //Relational properties
        public int DrinkCategoryId { get; set; }
        public DrinkCategory? DrinkCategory { get; set; }
    }
}
