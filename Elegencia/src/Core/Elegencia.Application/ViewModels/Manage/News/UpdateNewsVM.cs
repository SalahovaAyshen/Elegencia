using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class UpdateNewsVM
    {
        [Required(ErrorMessage = "Title can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Description can't be empty")]
        public string Description { get; set; } = null!;
        public string? Image {  get; set; }
        public IFormFile? Photo { get; set; } 

    }
}
