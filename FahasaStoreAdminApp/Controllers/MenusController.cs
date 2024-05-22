using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMenuService _MenuService;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;
        public MenusController(IMenuService MenuService, IMapper mapper, IImageUploader imageUploader)
        {
            _MenuService = MenuService;
            _mapper = mapper;
            _imageUploader = imageUploader;
        }

        // GET: MenuController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _MenuService.GetMenusAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: MenuController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Menu Menu, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Menu");
                Menu.PublicId = resImgUploader.PublicId;
                Menu.ImageUrl = resImgUploader.Url;

                var res = await _MenuService.AddMenuAsync(Menu);
                TempData["SuccessMessage"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Menu Menu, IFormFile fileImage)
        {
            try
            {
                var menuEdit = await _MenuService.GetMenuByIdAsync(id);
                if (fileImage == null)
                {
                    Menu.PublicId = menuEdit.PublicId;
                    Menu.ImageUrl = menuEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(menuEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Menu");
                    Menu.PublicId = resImageUploader.PublicId;
                    Menu.ImageUrl = resImageUploader.Url;
                }
                Menu.MenuId = id;
                var res = await _MenuService.UpdateMenuAsync(id, Menu);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var menuDelete = await _MenuService.GetMenuByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(menuDelete.PublicId);
                var Delete = await _MenuService.DeleteMenuAsync(id);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
