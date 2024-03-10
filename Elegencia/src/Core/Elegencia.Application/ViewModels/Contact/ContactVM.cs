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
        public string Name { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        public string? CommentText { get; set; } 

    }
}
