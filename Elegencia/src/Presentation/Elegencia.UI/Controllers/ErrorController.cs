using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ErrorPage(string error)
        {
            return View(model: error);
        }
    }
}
