using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Filters;

namespace FahasaStoreAdminApp.Controllers
{
    public class SubcategoriesController : GenericController<Subcategory, SubcategoryModel, SubcategoryDTO, int>
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _SubcategoryService;
        public SubcategoriesController(ICategoryService categoryService, ISubcategoryService SubcategoryService, IMapper mapper, IImageUploader imageUploader) : base(SubcategoryService, mapper, imageUploader)
        {
            _categoryService = categoryService;
            _SubcategoryService = SubcategoryService;
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<IActionResult> Index(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            ViewData["Categories"] = await _categoryService.GetAllAsync();
            return await base.Index(filters, sortField, sortDirection, page, size);
        }

        [Authorize(AppRole.Admin)]
        public override async Task<ActionResult> Create()
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

        [Authorize(AppRole.Admin)]
        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return await base.Edit(id);
        }

        [Authorize(AppRole.Admin)]
        public async Task<ActionResult> GetSubcategoriesByCategory(string id)
        {
            return PartialView(await _SubcategoryService.GetListByAsync("CategoryId", id));
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

    }
}
