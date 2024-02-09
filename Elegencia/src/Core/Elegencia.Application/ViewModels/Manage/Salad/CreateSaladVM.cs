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
    public class CreateSaladVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The salad ingredients can't be empty")]
        public string Ingredients { get; set; } = null!;
        public IFormFile Image { get; set; }
        public string Alternative { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Category>? Categories { get; set; }
    }
}
