using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class MessageService : IMessageService
    {
        private readonly IContactRepository _contactRepository;

        public MessageService(IContactRepository contactRepository)
        {
           _contactRepository = contactRepository;
        }
        public async Task<int> MessagesCount()
        {
            int count = await _contactRepository.CountAsync();
            return count;
        }
        public async Task<IQueryable<Contact>> GetAll()
        {
            IQueryable<Contact> contacts =  _contactRepository.GetAll();
            return contacts;
        }

        public async Task Readed(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Contact contact = await _contactRepository.GetByIdAsync(id);
            if (contact == null) throw new NotFoundException("Not found id");
            _contactRepository.Delete(contact);
            await _contactRepository.SaveChangesAsync();
        }
    }
}
