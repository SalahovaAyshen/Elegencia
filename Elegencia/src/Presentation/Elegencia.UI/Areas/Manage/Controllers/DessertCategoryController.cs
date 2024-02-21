﻿using Elegencia.Application.Abstractions.Services.Manage;
using Elegencia.Application.ViewModels.Manage;
using Elegencia.Domain.Entities;
using Elegencia.Domain.Enums;
using Elegencia.Persistence.Implementations.Services.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Elegencia.UI.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DessertCategoryController : Controller
    {
        private readonly IDessertCategoryService _dessertCategoryService;

        public DessertCategoryController(IDessertCategoryService dessertCategoryService)
        {
            _dessertCategoryService = dessertCategoryService;
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Index(int page = 1)
        {
            PaginationVM<DessertCategory> pagination = await _dessertCategoryService.GetAll(page:page, take:3);
            return View(pagination);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDessertCategoryVM categoryVM)
        {
            if (await _dessertCategoryService.PostCreate(categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully created {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Moderator))]
        public async Task<IActionResult> Update(int id)
        {
            UpdateDessertCategoryVM categoryVM = await _dessertCategoryService.GetUpdate(id);
            return View(categoryVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateDessertCategoryVM categoryVM)
        {
            if (await _dessertCategoryService.PostUpdate(id, categoryVM, ModelState))
            {
                TempData["Message"] = $"<div class=\"alert alert-success\" role=\"alert\">\r\n  Successfully updated {categoryVM.Name} \r\n</div>";
                return RedirectToAction(nameof(Index));

            }
            return View(categoryVM);
        }
        [Authorize(Roles = nameof(UserRole.Admin))]
        public async Task<IActionResult> Delete(int id)
        {
            await _dessertCategoryService.Delete(id);
            TempData["Message"] = $"<div class=\"alert alert-danger\" role=\"alert\">\r\n  Successfully deleted \r\n</div>";
            return RedirectToAction(nameof(Index));
        }
    }
}
