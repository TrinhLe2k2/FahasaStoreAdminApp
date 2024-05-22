using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoryService _SubcategoryService;
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;
        public SubcategoriesController(ISubcategoryService SubcategoryService, IMapper mapper, ICategoryService categoryService, IImageUploader imageUploader)
        {
            _SubcategoryService = SubcategoryService;
            _mapper = mapper;
            _CategoryService = categoryService;
            _imageUploader = imageUploader;
        }

        // GET: SubcategoryController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewData["Categories"] = await _CategoryService.GetCategorysAsync();
                return View(await _SubcategoryService.GetSubcategoriesAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: SubcategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _SubcategoryService.GetSubcategoryByIdAsync(id));
        }

        // GET: SubcategoryController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["Categories"] = new SelectList(await _CategoryService.GetCategorysAsync(), "CategoryId", "Name");
            return PartialView();
        }

        // POST: SubcategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Subcategory Subcategory, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Subcategory");
                Subcategory.PublicId = resImgUploader.PublicId;
                Subcategory.ImageUrl = resImgUploader.Url;

                var res = await _SubcategoryService.AddSubcategoryAsync(Subcategory);
                TempData["SuccessMessage"] = "Thêm mới thành công";
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
            ViewData["Categories"] = new SelectList(await _CategoryService.GetCategorysAsync(), "CategoryId", "Name");
            return PartialView(await _SubcategoryService.GetSubcategoryByIdAsync(id));
        }

        // POST: SubcategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Subcategory Subcategory, IFormFile fileImage)
        {
            try
            {
                var SubcategoryEdit = await _SubcategoryService.GetSubcategoryByIdAsync(id);
                if (fileImage == null)
                {
                    Subcategory.PublicId = SubcategoryEdit.PublicId;
                    Subcategory.ImageUrl = SubcategoryEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(SubcategoryEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Subcategory");
                    Subcategory.PublicId = resImageUploader.PublicId;
                    Subcategory.ImageUrl = resImageUploader.Url;
                }

                Subcategory.SubcategoryId = id;
                var res = await _SubcategoryService.UpdateSubcategoryAsync(id, Subcategory);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
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
            return PartialView(await _SubcategoryService.GetSubcategoryByIdAsync(id));
        }

        // POST: SubcategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var SubcategoryEdit = await _SubcategoryService.GetSubcategoryByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(SubcategoryEdit.PublicId);

                var SubcategoryDelete = await _SubcategoryService.DeleteSubcategoryAsync(id);
                TempData["SuccessMessage"] = "Xóa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetSubcategoriesByCategory(int id)
        {
            return PartialView(await _SubcategoryService.GetSubcategoriesByCategoryAsync(id));
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
