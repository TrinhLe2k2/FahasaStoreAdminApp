using AutoMapper;
using BookStoreAPI.Services;
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
        private readonly IImageUploader _imageUploader;

        public CategoriesController(ICategoryService CategoryService, IMapper mapper, IImageUploader imageUploader)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
            _imageUploader = imageUploader;
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
        public async Task<ActionResult> Create(Category Category, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Category");
                Category.PublicId = resImgUploader.PublicId;
                Category.ImageUrl = resImgUploader.Url;

                var res = await _CategoryService.AddCategoryAsync(Category);
                TempData["SuccessMessage"] = "Thêm mới thành công";
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
        public async Task<ActionResult> Edit(int id, Category Category, IFormFile fileImage)
        {
            try
            {
                var categoryEdit = await _CategoryService.GetCategoryByIdAsync(id);
                if (fileImage == null)
                {
                    Category.PublicId = categoryEdit.PublicId;
                    Category.ImageUrl = categoryEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(categoryEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Category");
                    Category.PublicId = resImageUploader.PublicId;
                    Category.ImageUrl = resImageUploader.Url;
                }
                Category.CategoryId = id;
                var res = await _CategoryService.UpdateCategoryAsync(id, Category);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
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
                var CategoryDelete = await _CategoryService.GetCategoryByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(CategoryDelete.PublicId);
                var Delete = await _CategoryService.DeleteCategoryAsync(id);
                TempData["SuccessMessage"] = "Xóa thành công";
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
