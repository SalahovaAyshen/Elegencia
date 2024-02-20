using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.ViewModels
{
    public class HomeVM
    {
        public ICollection<Meal> Meals { get; set; }
        public Dictionary<string,string> Service {  get; set; }
        public ReservationVM reservationVM { get; set; }
    }
}
