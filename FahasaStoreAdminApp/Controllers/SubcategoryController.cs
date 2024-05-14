using AutoMapper;
using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAdminApp.Models;
using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryService _SubcategoryService;
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        public SubcategoryController(ISubcategoryService SubcategoryService, IMapper mapper, ICategoryService categoryService)
        {
            _SubcategoryService = SubcategoryService;
            _mapper = mapper;
            _CategoryService = categoryService;
        }

        // GET: SubcategoryController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewData["Categories"] = await _CategoryService.GetCategorysAsync();

                var Subcategorys = await _SubcategoryService.GetSubcategoriesAsync();
                return View(Subcategorys);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: SubcategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Subcategory = await _SubcategoryService.GetSubcategoryByIdAsync(id);
            return PartialView(Subcategory);
        }

        // GET: SubcategoryController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _CategoryService.GetCategorysAsync(), "CategoryId", "Name");
            return PartialView();
        }

        // POST: SubcategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubcategoryForm SubcategoryForm)
        {
            if (SubcategoryForm.ImageUrl == null)
            {
                SubcategoryForm.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
            }
            try
            {
                var res = await _SubcategoryService.AddSubcategoryAsync(SubcategoryForm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error");
            }
        }

        // GET: SubcategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["CategoryId"] = new SelectList(await _CategoryService.GetCategorysAsync(), "CategoryId", "Name");
            var Subcategory = await _SubcategoryService.GetSubcategoryByIdAsync(id);
            return PartialView(_mapper.Map<SubcategoryForm>(Subcategory));
        }

        // POST: SubcategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, SubcategoryForm SubcategoryForm)
        {
            try
            {
                SubcategoryForm.SubcategoryId = id;
                var res = await _SubcategoryService.UpdateSubcategoryAsync(id, SubcategoryForm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubcategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Subcategory = await _SubcategoryService.GetSubcategoryByIdAsync(id);
            return PartialView(_mapper.Map<SubcategoryForm>(Subcategory));
        }

        // POST: SubcategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var SubcategoryDelete = await _SubcategoryService.DeleteSubcategoryAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetSubcategoriesByCategoryID(int id)
        {
            var Subcategories = await _SubcategoryService.GetSubcategoriesByCategoryID(id);
            return PartialView(Subcategories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
