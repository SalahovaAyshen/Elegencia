using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> PostContact(ContactVM contact, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;

            await _contactRepository.AddAsync(new Contact
            {
                Name = contact.Name,
                Email = contact.Email,
                CommentText = contact.CommentText,
            });
            await _contactRepository.SaveChangesAsync();
            return true;
        }
    }
}
