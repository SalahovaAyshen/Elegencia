using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Get()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Get(ContactVM contact)
        {
            if (await _service.PostContact(contact, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-light\" role=\"alert\">\r\n  Successfully send message \r\n</div>";
                return RedirectToAction("Index","Home");
            }
            return View(contact);
        }
    }
}
