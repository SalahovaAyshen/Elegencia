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
        [Required(ErrorMessage ="The name can't be empty")]
        [MinLength(3,ErrorMessage ="The name length can't be less than 3")]
        [MaxLength(25,ErrorMessage ="The name length can't be more than 25")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The surname can't be empty")]
        [MinLength(3, ErrorMessage = "The surname length can't be less than 3")]
        [MaxLength(25, ErrorMessage = "The surname length can't be more than 25")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="The information about chef can't be empty")]
        public string Info { get; set; }
        [Required(ErrorMessage = "The facebook link can't be empty")]
        public string Facebook { get; set; }
        [Required(ErrorMessage = "The instagram link can't be empty")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "The linkedin link can't be empty")]
        public string Linkedin { get; set; }
        public IFormFile Photo { get; set; } = null!;
        public int PositionId { get; set; }
        public ICollection<Position>? Positions { get; set; }
    }
}
