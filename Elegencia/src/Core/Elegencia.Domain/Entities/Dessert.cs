using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Dessert:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public string Ingredients { get; set; } = null!;
        //Relational properties
        public int DessertCategoryId { get; set; }
        public DessertCategory? DessertCategory { get; set; }
        public List<DessertImage>? DessertImages { get; set; }

    }
}
