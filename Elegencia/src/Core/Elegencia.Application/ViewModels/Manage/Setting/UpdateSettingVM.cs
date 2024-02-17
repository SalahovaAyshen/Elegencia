using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels.Manage
{
    public class UpdateSettingVM
    {
        [Required(ErrorMessage ="Value can't be null")]
        public string Value { get; set; }
    }
}
