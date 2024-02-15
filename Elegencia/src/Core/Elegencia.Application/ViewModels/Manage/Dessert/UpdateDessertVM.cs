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
    public class UpdateDessertVM
    {
        [Required(ErrorMessage = "The name can't be empty")]

        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The price can't be empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The meal ingredients can't be empty")]
        public string Ingredients { get; set; } = null!;
        public string? MainImage { get; set; }
        public string? HoverImage { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public int DessertCategoryId { get; set; }
        public ICollection<DessertCategory>? DessertCategories { get; set; }
        public ICollection<DessertImage>? DessertImages { get; set; }
    }
}
