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
    public class CreateDessertVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The price can't be empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The dessert ingredients can't be empty")]
        public string Ingredients { get; set; } = null!;
        public int DessertCategoryId { get; set; }
        public ICollection<DessertCategory>? DessertCategories { get; set; }
        [Required(ErrorMessage = "The main photo must be selected")]
        public IFormFile MainPhoto { get; set; } = null!;
        [Required(ErrorMessage = "The hover photo must be selected")]
        public IFormFile HoverPhoto { get; set; } = null!;
    }
}
