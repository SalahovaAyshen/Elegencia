using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class DessertImage:BaseEntity
    {
        public string Image { get; set; } = null!;
        public bool? IsPrimary { get; set; }
        public string? Alternative { get; set; }
        //Relational properties
        public int DessertId { get; set; }
        public Dessert? Dessert { get; set; }
    }
}
