using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class NewsVM
    {
        public ICollection<News> News { get; set; }
    }
}
