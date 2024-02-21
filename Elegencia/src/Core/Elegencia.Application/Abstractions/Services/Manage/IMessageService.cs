using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Application.Abstractions.Services.Manage
{
    public interface IMessageService
    {
        Task<int> MessagesCount();
        Task<IQueryable<Contact>> GetAll();
        Task Readed(int id);
    }
}
