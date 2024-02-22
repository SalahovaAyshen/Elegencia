using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "Name can't be empty")]
        [MinLength(3,ErrorMessage ="The name can't be less than 3")]
        [MaxLength(25, ErrorMessage = "The name can't be more than 25")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname can't be empty")]
        [MinLength(3, ErrorMessage = "The Surname can't be less than 3")]
        [MaxLength(25, ErrorMessage = "The Surname can't be more than 25")]
        public string Surname { get; set; }
        public string? Username { get; set; }
        [Required(ErrorMessage = "Email can't be empty")]
        [MinLength(3, ErrorMessage = "The Email can't be less than 3")]
        [MaxLength(254, ErrorMessage = "The Email can't be more than 254")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Image { get; set; }
        public IFormFile? Photo { get; set; }
        [MinLength(8, ErrorMessage ="The password can't less than 8 characters")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Compare(nameof(NewPassword))]
        public string? ConfirmPassword { get; set; }
        public int MessagesCount { get; set; }
    }
}
