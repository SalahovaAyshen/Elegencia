using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IMessageService _messageService;

        public UserController(IUserService service, IMessageService messageService)
        {
            _service = service;
            _messageService = messageService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> UserSettings()
        {
            UserVM user = await _service.GetUser();
            int messageCount=await _messageService.MessagesCount();
            IQueryable<Contact> contacts = await _messageService.GetAll();
            user.MessagesCount = messageCount;
            user.Contacts = contacts;

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UserSettings(UserVM user)
        {
            if(await _service.UpdateUser(user, ModelState))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(user);
        }
        public async Task<IActionResult> DeletePhoto()
        {
            await _service.DeletePhoto();
            return RedirectToAction("Index", "Dashboard");
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]

        public async Task<IActionResult> ReadMessage(int id)
        {
            await _messageService.Readed(id);
            return RedirectToAction(nameof(UserSettings));
        }
    }
}
