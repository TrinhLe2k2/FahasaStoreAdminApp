using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class SubcategoriesController : GenericController<Subcategory, SubcategoryModel, int>
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubcategoryService _SubcategoryService;
        public SubcategoriesController(ICategoryService categoryService, ISubcategoryService SubcategoryService, IMapper mapper, IImageUploader imageUploader) : base(SubcategoryService, mapper, imageUploader)
        {
            _categoryService = categoryService;
            _SubcategoryService = SubcategoryService;
        }

        public override async Task<IActionResult> Index()
        {
            ViewData["Categories"] = await _categoryService.GetAllAsync();
            return await base.Index();
        }

        public override async Task<ActionResult> Create()
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return await base.Edit(id);
        }

        public async Task<ActionResult> GetSubcategoriesByCategory(string id)
        {
            return PartialView(await _SubcategoryService.GetListByAsync("CategoryId", id));
        }
    }
}
