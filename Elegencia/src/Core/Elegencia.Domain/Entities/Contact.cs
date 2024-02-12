using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Contact:BaseNameableEntity
    {
        public string Email { get; set; }
        public string CommentText { get; set; }
    }
}
