using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Domain.Entities
{
    public class Reservation:BaseNameableEntity
    {
        public string Email { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public string ArrivalDate => ArrivalDateTime.ToString("MM/dd/yyyy");
        public string ArrivalTime => ArrivalDateTime.ToString("h:mm tt");

    }
}
