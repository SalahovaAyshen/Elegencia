using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<News> news = await _newsService.GetAll();
            return View(news);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsVM newsVM)
        {
            if (await _newsService.CreatePost(newsVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {newsVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(newsVM);
        }
        public async Task<IActionResult> Update(int id)
        {
            UpdateNewsVM newsVM = await _newsService.GetUpdate(id);
            return View(newsVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateNewsVM newsVM)
        {
            if (await _newsService.PostUpdate(id,newsVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {newsVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(newsVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _newsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
