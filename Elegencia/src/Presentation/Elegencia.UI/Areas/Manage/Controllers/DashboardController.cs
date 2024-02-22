using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        private readonly IAccountService _service;
        private readonly IMessageService _messageService;

        public DashboardController(IAccountService service, IMessageService messageService)
        {
            _service = service;
            _messageService = messageService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index()
        {
            int count = await _service.UserCount();
            int mesCount = await _messageService.MessagesCount();
            IQueryable<Contact> contacts = await _messageService.GetAll();
            DashboardVM dashboard = new DashboardVM
            {
                UserCount = count,
                Contacts = contacts,
                MessageCount = mesCount
            };
            return View(dashboard);
        }
      
    }
}
