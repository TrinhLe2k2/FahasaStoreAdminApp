using BookStoreAPI.Services;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class BannersController : Controller
    {
        private readonly IBannerService _BannerService;
        private readonly IImageUploader _imageUploader;
        public BannersController(IBannerService BannerService, IImageUploader imageUploader)
        {
            _BannerService = BannerService;
            _imageUploader = imageUploader;
        }

        // GET: BannerController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _BannerService.GetBannersAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: BannerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _BannerService.GetBannerByIdAsync(id));
        }

        // GET: BannerController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: BannerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Banner Banner, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Banner");
                Banner.PublicId = resImgUploader.PublicId;
                Banner.ImageUrl = resImgUploader.Url;

                Banner.CreatedAt = DateTime.Now;
                var res = await _BannerService.AddBannerAsync(Banner);
                TempData["SuccessMessage"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BannerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _BannerService.GetBannerByIdAsync(id));
        }

        // POST: BannerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Banner Banner, IFormFile fileImage)
        {
            try
            {
                var bannerEdit = await _BannerService.GetBannerByIdAsync(id);
                if (fileImage == null)
                {
                    Banner.PublicId = bannerEdit.PublicId;
                    Banner.ImageUrl = bannerEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(bannerEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Banner");
                    Banner.PublicId = resImageUploader.PublicId;
                    Banner.ImageUrl = resImageUploader.Url;
                }
                Banner.BannerId = id;
                Banner.CreatedAt = bannerEdit.CreatedAt;

                var res = await _BannerService.UpdateBannerAsync(id, Banner);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BannerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _BannerService.GetBannerByIdAsync(id));
        }

        // POST: BannerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var BannerDelete = await _BannerService.GetBannerByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(BannerDelete.PublicId);
                var Delete = await _BannerService.DeleteBannerAsync(id);
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
