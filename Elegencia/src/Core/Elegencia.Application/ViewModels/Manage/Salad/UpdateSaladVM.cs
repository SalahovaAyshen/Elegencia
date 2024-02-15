using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class UpdateSaladVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The price can't be empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The salad ingredients can't be empty")]
        public string Ingredients { get; set; } = null!;
        public string? Image { get; set; }
        public IFormFile? Photo { get; set; } 
        public string? Alternative { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
