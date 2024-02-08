﻿using Elegencia.Domain.Entities;
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
        [Required(ErrorMessage ="The name can't be empty")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required(ErrorMessage ="The meal ingredients can't be empty")]
        public string Ingredients { get; set; } = null!;
        public int CategoryId { get; set; }
        public ICollection<Category>? Categories { get; set; }
        [Required(ErrorMessage ="The main photo must be selected")]
        public IFormFile MainPhoto { get; set; } = null!;
        [Required(ErrorMessage = "The hover photo must be selected")]
        public IFormFile HoverPhoto { get; set; } = null!;
    }
}
