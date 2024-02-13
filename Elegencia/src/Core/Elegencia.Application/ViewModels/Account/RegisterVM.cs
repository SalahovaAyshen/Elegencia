using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        [MinLength(3, ErrorMessage = "The length of the name can't be less than 3")]
        [MaxLength(25, ErrorMessage = "The length of the name can't be more than 25")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The surname can't be empty")]
        [MinLength(3, ErrorMessage = "The length of the surname can't be less than 3")]
        [MaxLength(25, ErrorMessage = "The length of the surname can't be more than 25")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "The username can't be empty")]
        [MinLength(4, ErrorMessage = "The length of the username can't be less than 3")]
        [MaxLength(240, ErrorMessage = "The length of the username can't be more than 40")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The email can't be empty")]
        [MinLength(9, ErrorMessage = "The length of the email can't be less than 9")]
        [MaxLength(320, ErrorMessage = "The length of the email can't be more than 320")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must entire password")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string? Image { get; set; }
    }
}
