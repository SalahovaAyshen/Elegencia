using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Position:BaseNameableEntity
    {
        //Relational properties
        public ICollection<Chef>? Chefs { get; set; }
    }
}
