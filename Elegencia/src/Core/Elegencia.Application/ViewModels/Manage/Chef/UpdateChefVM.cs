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
    public class UpdateChefVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "The surname can't be empty")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "The information about chef can't be empty")]
        public string Info { get; set; } = null!;
        [Required(ErrorMessage = "The facebook link can't be empty")]
        public string Facebook { get; set; } = null!;
        [Required(ErrorMessage = "The instagram link can't be empty")]
        public string Instagram { get; set; } = null!;
        [Required(ErrorMessage = "The linkedin link can't be empty")]
        public string Linkedin { get; set; } = null!;
        public string? Image { get; set; }
        public IFormFile? Photo { get; set; } = null!;
        public int PositionId { get; set; }
        public ICollection<Position>? Positions { get; set; }
    }
}
