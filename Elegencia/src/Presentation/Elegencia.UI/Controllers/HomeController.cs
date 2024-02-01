using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
