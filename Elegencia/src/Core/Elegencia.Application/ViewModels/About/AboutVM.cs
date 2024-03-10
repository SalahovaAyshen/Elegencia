using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class AboutVM
    {
        public Dictionary<string, string> Services { get; set; }
        public IQueryable<Famous> Famous { get; set; }
    }
}
