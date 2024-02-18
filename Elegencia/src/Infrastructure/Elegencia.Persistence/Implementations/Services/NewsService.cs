using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.ViewModels;
using Elegencia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<NewsVM> GetAll()
        {
            ICollection<News> newsVM = await _newsRepository.GetAllWithOrder(expression: m => m.IsDeleted == false).ToListAsync();
            NewsVM news = new NewsVM
            {
                News = newsVM
            };
            return news;
        }
    }
}
