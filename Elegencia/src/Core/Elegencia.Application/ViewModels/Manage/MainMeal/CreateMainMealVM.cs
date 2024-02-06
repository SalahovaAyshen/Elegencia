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
    public class CreateMainMealVM
    {
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        [Required]
        public string Ingredients { get; set; } = null!;
        public int CategoryId { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public IFormFile MainPhoto { get; set; } = null!;
        public IFormFile HoverPhoto { get; set; } = null!;
    }
}
