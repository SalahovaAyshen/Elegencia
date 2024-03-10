using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.Manage
{
    public interface IReservationService
    {
        Task<int> ReservationCount();
        Task<IQueryable<Reservation>> GetAll();
        Task Accept(int id);
        Task Reject(int id);
    }
}
