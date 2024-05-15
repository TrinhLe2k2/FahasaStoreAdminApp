using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _CategoryService.GetCategorysAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _CategoryService.GetCategoryByIdAsync(id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category Category)
        {
            try
            {
                if (Category.ImageUrl == null)
                {
                    Category.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
                }
                var res = await _CategoryService.AddCategoryAsync(Category);
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
            return PartialView(await _CategoryService.GetCategoryByIdAsync(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category Category)
        {
            try
            {
                Category.CategoryId = id;
                var res = await _CategoryService.UpdateCategoryAsync(id, Category);
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
            return PartialView(await _CategoryService.GetCategoryByIdAsync(id));
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
