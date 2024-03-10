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

namespace Elegencia.Persistence.Implementations.Services.Manage
{
    public class DessertService : IDessertService
    {
        private readonly IDessertRepository _dessertRepository;
        private readonly IDessertCategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly IAccountService _user;

        public DessertService(IDessertRepository dessertRepository, 
            IDessertCategoryRepository categoryRepository, 
            IWebHostEnvironment env,
            IHttpContextAccessor http,
            IAccountService user)
        {
            _dessertRepository = dessertRepository;
            _categoryRepository = categoryRepository;
            _env = env;
            _http = http;
            _user = user;
        }

       

        public async Task<PaginationVM<Dessert>> GetAll(int page, int take)
        {
            PaginationVM<Dessert> desserts = await _dessertRepository.GetAllPagination(expression: m => m.IsDeleted == false, page: page, take: take, includes: nameof(Dessert.DessertImages));
            return desserts;
        }
        public async Task<CreateDessertVM> GetCreate()
        {
            CreateDessertVM dessertVM = new CreateDessertVM();
            dessertVM.DessertCategories = await _categoryRepository.GetAll().ToListAsync();
            return dessertVM;
        }

       

        public async Task<bool> PostCreate(CreateDessertVM dessertVM, ModelStateDictionary modelState)
        {
            dessertVM.DessertCategories = await _categoryRepository.GetAll().ToListAsync();
            if (!modelState.IsValid) return false;
            if (await _dessertRepository.GetAll().AnyAsync(c => c.Name.ToLower() == dessertVM.Name.ToLower()))
            {
                modelState.AddModelError("Name", "The dessert name is existed");
                return false;
            }
            if (dessertVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _categoryRepository.GetAll().AnyAsync(c => c.Id == dessertVM.DessertCategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }
            if (!dessertVM.MainPhoto.ValidateType("image/"))
            {
                modelState.AddModelError("MainPhoto", "The image type should be img");
                return false;
            }
            if (!dessertVM.MainPhoto.VaidateSize(5000))
            {
                modelState.AddModelError("MainPhoto", "The image size is too large");
                return false;
            }
            if (!dessertVM.HoverPhoto.ValidateType("image/"))
            {
                modelState.AddModelError("HoverPhoto", "The image type should be img");
                return false;
            }
            if (!dessertVM.HoverPhoto.VaidateSize(5000))
            {
                modelState.AddModelError("HoverPhoto", "The image size is too large");
                return false;
            }
            DessertImage mainPhoto = new DessertImage
            {
                IsPrimary = true,
                Image = await dessertVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative = dessertVM.Name

            };
            DessertImage hoverPhoto = new DessertImage
            {
                IsPrimary = false,
                Image = await dessertVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img"),
                Alternative = dessertVM.Name
            };
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            await _dessertRepository.AddAsync(new Dessert
            {
                Name = dessertVM.Name,
                Price = dessertVM.Price,
                Ingredients = dessertVM.Ingredients,
                DessertCategoryId = dessertVM.DessertCategoryId,
                DessertImages = new List<DessertImage> { mainPhoto, hoverPhoto },
                CreatedAt = DateTime.Now,
                CreatedBy = user.Name + " " + user.Surname
            });
            await _dessertRepository.SaveChangesAsync();
            return true;
        }
        public async Task<UpdateDessertVM> GetUpdate(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number ");
            Dessert dessert = await _dessertRepository.GetByIdAsync(id, includes: nameof(Dessert.DessertImages));
            if (dessert == null) throw new NotFoundException("Not found id");
            UpdateDessertVM updateDessertVM = new UpdateDessertVM
            {
                Name = dessert.Name,
                Price = dessert.Price,
                Ingredients = dessert.Ingredients,
                DessertCategoryId = dessert.DessertCategoryId,
                DessertCategories = await _categoryRepository.GetAll().ToListAsync(),
                DessertImages = dessert.DessertImages,
                MainImage = dessert.DessertImages.FirstOrDefault(mi => mi.IsPrimary == true)?.Image,
                HoverImage = dessert.DessertImages.FirstOrDefault(mi => mi.IsPrimary == false)?.Image
            };
            return updateDessertVM;
        }
        public async Task<bool> PostUpdate(int id, UpdateDessertVM dessertVM, ModelStateDictionary modelState)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number ");
            dessertVM.DessertCategories = await _categoryRepository.GetAll().ToListAsync();
            Dessert existed = await _dessertRepository.GetByIdAsync(id, includes: nameof(Dessert.DessertImages));
            if (existed == null) throw new NotFoundException("Not found id");
            dessertVM.DessertImages = existed.DessertImages;
            dessertVM.MainImage = existed.DessertImages.FirstOrDefault(mi => mi.IsPrimary == true)?.Image;
            dessertVM.HoverImage = existed.DessertImages.FirstOrDefault(mi => mi.IsPrimary == false)?.Image;
            if (!modelState.IsValid) return false;
            if (await _dessertRepository.GetAll().AnyAsync(c => c.Name.ToLower() == dessertVM.Name.ToLower() && c.Id != id))
            {
                modelState.AddModelError("Name", "The dessert name is existed");
                return false;
            }
            if (dessertVM.Price <= 0)
            {
                modelState.AddModelError("Price", "Price can't be zero or negative number");
                return false;
            }
            if (!await _categoryRepository.GetAll().AnyAsync(c => c.Id == dessertVM.DessertCategoryId))
            {
                modelState.AddModelError("CategoryId", "Wrong category id");
                return false;
            }

            if (dessertVM.MainPhoto != null)
            {
                if (!dessertVM.MainPhoto.ValidateType("image/"))
                {
                    modelState.AddModelError("MainPhoto", "The entered photo type does not match the required one");
                    return false;
                }
                if (!dessertVM.MainPhoto.VaidateSize(500))
                {
                    modelState.AddModelError("MainPhoto", "The size of the photo is larger than required");
                    return false;
                }
            }
            if (dessertVM.HoverPhoto != null)
            {
                if (!dessertVM.HoverPhoto.ValidateType("image/"))
                {
                    modelState.AddModelError("HoverPhoto", "The entered photo type does not match the required one");
                    return false;
                }
                if (!dessertVM.HoverPhoto.VaidateSize(500))
                {
                    modelState.AddModelError("HoverPhoto", "The size of the photo is larger than required");
                    return false;
                }
            }
            if (dessertVM.MainPhoto != null)
            {
                string main = await dessertVM.MainPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img");
                DessertImage exImage = existed.DessertImages.FirstOrDefault(pi => pi.IsPrimary == true);
                exImage.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                existed.DessertImages.Remove(exImage);
                existed.DessertImages.Add(new DessertImage
                {
                    IsPrimary = true,
                    Image = main,
                    Alternative = dessertVM.Name
                });
            }
            if (dessertVM.HoverPhoto != null)
            {
                string hover = await dessertVM.HoverPhoto.CreateFileAsync(_env.WebRootPath, "assets", "img");
                DessertImage exImage = existed.DessertImages.FirstOrDefault(pi => pi.IsPrimary == false);
                exImage.Image.DeleteFile(_env.WebRootPath, "assets", "img");
                existed.DessertImages.Remove(exImage);
                existed.DessertImages.Add(new DessertImage
                {
                    IsPrimary = false,
                    Image = hover,
                    Alternative = dessertVM.Name
                });
            }
            AppUser user = await _user.GetUser(_http.HttpContext.User.Identity.Name);
            existed.Name = dessertVM.Name;
            existed.Price = dessertVM.Price;
            existed.Ingredients = dessertVM.Ingredients;
            existed.DessertCategoryId = dessertVM.DessertCategoryId;
            existed.ModifiedAt = DateTime.Now;
            existed.ModifiedBy = user.Name + " " + user.Surname;
            _dessertRepository.Update(existed);
            await _dessertRepository.SaveChangesAsync();
            return true;

        }
        public async Task Delete(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Dessert dessert = await _dessertRepository.GetByIdAsync(id);
            if (dessert is null) throw new NotFoundException("Not found id");
            dessert.IsDeleted = true;
            await _dessertRepository.SaveChangesAsync();
        }

        public async Task<Dessert> Detail(int id)
        {
            if (id <= 0) throw new WrongRequestException("Id can't be zero or negative number");
            Dessert dessert = await _dessertRepository.GetByIdAsync(id, includes: new string[] { nameof(Dessert.DessertImages), nameof(Dessert.DessertCategory) });
            if (dessert is null) throw new NotFoundException("Not found id");
            return dessert;
        }
    }
}
