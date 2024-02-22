using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
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
        public async Task<IActionResult> UserSettings()
        {
            UserVM user = await _service.GetUser();
            int messageCount=await _messageService.MessagesCount();
            user.MessagesCount = messageCount;
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
    }
}
