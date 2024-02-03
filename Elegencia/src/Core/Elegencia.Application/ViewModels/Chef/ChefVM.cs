using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class ChefVM
    {
        public ICollection<Chef> Chefs { get; set; }
        public Chef Chef { get; set; }
    }
}
