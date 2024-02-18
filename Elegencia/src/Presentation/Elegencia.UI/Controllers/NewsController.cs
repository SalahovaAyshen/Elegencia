using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            NewsVM news = await _newsService.GetAll();
            return View(news);

        }
    }
}
