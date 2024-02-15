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
    public class CreateDrinkVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The price can't be empty")]
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; } = null!;
        public string? Alternative { get; set; }
        public int DrinkCategoryId { get; set; }
        public ICollection<DrinkCategory>? DrinkCategories { get; set; }
    }
}
