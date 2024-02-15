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
    public class CreateChefVM
    {
        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Surname can't be empty")]
        public string Surname { get; set; } = null!;
        [Required(ErrorMessage = "Information about chef can't be empty")]
        public string Info { get; set; } = null!;
        [Required(ErrorMessage = "Facebook link can't be empty")]
        public string Facebook { get; set; } = null!;
        [Required(ErrorMessage = "Instagram link can't be empty")]
        public string Instagram { get; set; } = null!;
        [Required(ErrorMessage = "Linkedin link can't be empty")]
        public string Linkedin { get; set; } = null!;
        public IFormFile Photo { get; set; } = null!;
        public int PositionId { get; set; }
        public ICollection<Position>? Positions { get; set; }
    }
}
