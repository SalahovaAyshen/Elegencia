using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class DessertTag:BaseEntity
    {
        //Relational properties
        public int DessertId { get; set; }
        public Dessert? Dessert { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
