using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class ContactController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
