using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class News : BaseNameableEntity
    {
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
