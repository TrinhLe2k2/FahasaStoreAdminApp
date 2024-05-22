using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class PlatformController : Controller
    {
        private readonly IPlatformService _PlatformService;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;
        public PlatformController(IPlatformService PlatformService, IMapper mapper, IImageUploader imageUploader)
        {
            _PlatformService = PlatformService;
            _mapper = mapper;
            _imageUploader = imageUploader;
        }

        // GET: PlatformController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _PlatformService.GetPlatformsAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PlatformController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _PlatformService.GetPlatformByIdAsync(id));
        }

        // GET: PlatformController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: PlatformController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Platform Platform, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Platform");
                Platform.PublicId = resImgUploader.PublicId;
                Platform.ImageUrl = resImgUploader.Url;

                var res = await _PlatformService.AddPlatformAsync(Platform);
                TempData["SuccessMessage"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatformController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _PlatformService.GetPlatformByIdAsync(id));
        }

        // POST: PlatformController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Platform Platform, IFormFile fileImage)
        {
            try
            {
                var PlatformEdit = await _PlatformService.GetPlatformByIdAsync(id);
                if (fileImage == null)
                {
                    Platform.PublicId = PlatformEdit.PublicId;
                    Platform.ImageUrl = PlatformEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(PlatformEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Platform");
                    Platform.PublicId = resImageUploader.PublicId;
                    Platform.ImageUrl = resImageUploader.Url;
                }

                Platform.PlatformId = id;
                var res = await _PlatformService.UpdatePlatformAsync(id, Platform);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatformController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _PlatformService.GetPlatformByIdAsync(id));
        }

        // POST: PlatformController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PlatformDelete = await _PlatformService.GetPlatformByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(PlatformDelete.PublicId);

                var Delete = await _PlatformService.DeletePlatformAsync(id);
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
