using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class CreatePositionVM
    {
        [Required(ErrorMessage = "The name can't be empty")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
