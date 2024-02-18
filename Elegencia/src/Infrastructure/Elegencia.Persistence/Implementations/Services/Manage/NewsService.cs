using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IWebHostEnvironment _env;

        public NewsService(INewsRepository newsRepository, IWebHostEnvironment env)
        {
            _newsRepository = newsRepository;
            _env = env;
        }
        async Task<ICollection<News>> INewsService.GetAll()
        {
            ICollection<News> news = await _newsRepository.GetAllWithOrder(expression: e=>e.IsDeleted==false).ToListAsync();
            return news;
        }
        public async Task<bool> CreatePost(CreateNewsVM newsVM, ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) return false;
            if (await _newsRepository.GetAll().AnyAsync(c => c.Name.ToLower() == newsVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The meal name is existed");
                return false;
            }
            if (!newsVM.Photo.ValidateType("image/"))
            {
                modelState.AddModelError("Photo", "The image type should be img");
                return false;
            }
            if (!newsVM.Photo.VaidateSize(500))
            {
                modelState.AddModelError("Photo", "The image size is too large");
                return false;
            }
            await _newsRepository.AddAsync(new News
            {
                Name = newsVM.Name,
                Description = newsVM.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = "ayshen",
                Image = await newsVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
            });
            await _newsRepository.SaveChangesAsync();
            return true;
        }

        public async Task<UpdateNewsVM> GetUpdate(int id)
        {
            if (id <= 0) throw new Exception("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new Exception("Not found id");
            UpdateNewsVM newsVM = new UpdateNewsVM
            {
                Name = news.Name,
                Description = news.Description,
                Image = news.Image
            };
            return newsVM;
        }

        public async Task<bool> PostUpdate(int id, UpdateNewsVM updateVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new Exception("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new Exception("Not found id");
            if (await _newsRepository.GetAll().AnyAsync(c => c.Name.ToLower() == updateVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The meal name is existed");
                return false;
            }
            if(updateVM.Photo != null)
            {
                if (!updateVM.Photo.ValidateType("image/"))
                {
                    modelState.AddModelError("Photo", "The image type should be img");
                    return false;
                }
                if (!updateVM.Photo.VaidateSize(500))
                {
                    modelState.AddModelError("Photo", "The image size is too large");
                    return false;
                }
                news.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                news.Image = await updateVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img");
            }
            news.Name = updateVM.Name;
            news.Description = updateVM.Description;
            news.ModifiedAt = DateTime.Now;
            news.ModifiedBy = "ayshen";
            await _newsRepository.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new Exception("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new Exception("Not found id");
            news.IsDeleted = true;
            await _newsRepository.SaveChangesAsync();
        }
    }
}
