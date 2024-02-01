using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Chef:BaseNameableEntity
    {
        public string Surname { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public string Linkedin { get; set; } = null!;

        //Relational properties
        public int PositionId { get; set; }
        public Position Position { get; set; } = null!;
    }
}

