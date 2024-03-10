using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class CreateFamousVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string Opinion { get; set; }
        public IFormFile Photo { get; set; }
    }
}
