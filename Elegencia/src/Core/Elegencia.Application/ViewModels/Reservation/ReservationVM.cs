using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class ReservationVM
    {
        [Required(ErrorMessage ="Name can't be empty")]
        [MinLength(3, ErrorMessage="Name can't be less than 3")]
        [MaxLength(25, ErrorMessage = "Name can't be more than 25")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public string ArrivalDate {get; set;}
        public string ArrivalTime { get; set; }
        public DateTime ArrivalDateTime => DateTime.ParseExact($"{ArrivalDate} {ArrivalTime}", "MM/dd/yyyy h:mm tt", CultureInfo.GetCultureInfo("en-US"));
    }
}
