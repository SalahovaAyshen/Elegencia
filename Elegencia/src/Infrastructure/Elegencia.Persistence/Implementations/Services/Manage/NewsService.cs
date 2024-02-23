using Elegencia.Application.Abstractions.Repositories;
using Elegencia.Application.Abstractions.Services;
using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.Utilities.Exceptions;
using Elegencia.Application.Utilities.Extensions;
using Elegencia.Application.ViewModels;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Persistence.Implementations.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INewsService = Elegencia.Application.Abstractions.Services.Manage.INewsService;

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public NewsService(INewsRepository newsRepository, IWebHostEnvironment env, IHttpContextAccessor http, IAccountService user)
        {
            _newsRepository = newsRepository;
            _env = env;
            _http = http;
            _user = user;
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
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            await _newsRepository.AddAsync(new News
            {
                Name = newsVM.Name,
                Description = newsVM.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname,
                Image = await newsVM.Photo.CreateFileAsync(_env.WebRootPath, "assets", "img"),
            });
            await _newsRepository.SaveChangesAsync();
            return true;
        }

        public async Task<UpdateNewsVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new NotFoundException("Not found id");
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
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new NotFoundException("Not found id");
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
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);

            news.Name = updateVM.Name;
            news.Description = updateVM.Description;
            news.ModifiedAt = DateTime.Now;
            news.ModifiedBy = user.Name + " " + user.Surname;
            await _newsRepository.SaveChangesAsync();
            return true;
        }

        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            News news = await _newsRepository.GetByIdAsync(id);
            if (news == null) throw new NotFoundException("Not found id");
            news.IsDeleted = true;
            await _newsRepository.SaveChangesAsync();
        }
    }
}
