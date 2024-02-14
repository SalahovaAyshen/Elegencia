using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Username or email can't be empty")]
        [MinLength(4,ErrorMessage ="Username or email can't be less than 4")]
        [MaxLength(320, ErrorMessage = "Username or email can't be more than 320")]
        public string UsernameOrEmail { get; set; }
        [Required(ErrorMessage = "You must entire password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsRemembered { get; set; }
    }
}
