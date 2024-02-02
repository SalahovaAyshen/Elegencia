using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Salad:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public string Ingredients { get; set; } = null!;
        public string Image { get; set; }
        public string Alternative { get; set; }

        //Relational properties
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
