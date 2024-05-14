using AutoMapper;
using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAdminApp.Models;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            try
            {
                var Categorys = await _CategoryService.GetCategorysAsync();
                return View(Categorys);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Category = await _CategoryService.GetCategoryByIdAsync(id);
            return PartialView(Category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryForm CategoryForm)
        {
            if(CategoryForm.ImageUrl == null)
            {
                CategoryForm.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
            }
            try
            {
                var res = await _CategoryService.AddCategoryAsync(CategoryForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error");
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var Category = await _CategoryService.GetCategoryByIdAsync(id);
            return PartialView(_mapper.Map<CategoryForm>(Category));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CategoryForm CategoryForm)
        {
            try
            {
                CategoryForm.CategoryId = id;
                var res = await _CategoryService.UpdateCategoryAsync(id, CategoryForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Category = await _CategoryService.GetCategoryByIdAsync(id);
            return PartialView(_mapper.Map<CategoryForm>(Category));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var CategoryDelete = await _CategoryService.DeleteCategoryAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
