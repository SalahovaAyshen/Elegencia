using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Famous:BaseNameableEntity
    {
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public string Opinion { get; set; }

    }
}
