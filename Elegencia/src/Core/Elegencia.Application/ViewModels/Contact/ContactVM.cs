using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class ContactVM
    {
        [Required(ErrorMessage ="The name can't be empty")]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "The comment text can't be empty")]
        public string CommentText { get; set; }

    }
}
