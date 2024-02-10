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
    public class UpdateMainMealVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The price can't be empty")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The meal ingredients can't be empty")]
        public string Ingredients { get; set; }
        public string? MainImage { get; set; }
        public string? HoverImage { get; set; }
        public IFormFile? MainPhoto { get; set; }
        public IFormFile? HoverPhoto { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<MealImages>? MealImages { get; set; }
    }
}
