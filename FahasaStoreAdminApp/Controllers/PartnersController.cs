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
    public class PartnersController : Controller
    {
        private readonly IPartnerService _PartnerService;
        private readonly IPartnerTypeService _PartnerTypeService;
        private readonly IMapper _mapper;
        private readonly IImageUploader _imageUploader;
        public PartnersController(IPartnerService PartnerService, IMapper mapper, IPartnerTypeService PartnerTypeService, IImageUploader imageUploader)
        {
            _PartnerService = PartnerService;
            _mapper = mapper;
            _PartnerTypeService = PartnerTypeService;
            _imageUploader = imageUploader;
        }

        // GET: PartnerController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewData["PartnerTypes"] = await _PartnerTypeService.GetPartnerTypesAsync();
                return View(await _PartnerService.GetPartnersAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _PartnerService.GetPartnerByIdAsync(id));
        }

        // GET: PartnerController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["PartnerTypes"] = new SelectList(await _PartnerTypeService.GetPartnerTypesAsync(), "PartnerTypeId", "Name");
            return PartialView();
        }

        // POST: PartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Partner Partner, IFormFile fileImage)
        {
            try
            {
                var resImgUploader = await _imageUploader.UploadImageAsync(fileImage, "Partner");
                Partner.PublicId = resImgUploader.PublicId;
                Partner.ImageUrl = resImgUploader.Url;

                var res = await _PartnerService.AddPartnerAsync(Partner);
                TempData["SuccessMessage"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["PartnerTypes"] = new SelectList(await _PartnerTypeService.GetPartnerTypesAsync(), "PartnerTypeId", "Name");
            return PartialView(await _PartnerService.GetPartnerByIdAsync(id));
        }

        // POST: PartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Partner Partner, IFormFile fileImage)
        {
            try
            {
                var PartnerEdit = await _PartnerService.GetPartnerByIdAsync(id);
                if (fileImage == null)
                {
                    Partner.PublicId = PartnerEdit.PublicId;
                    Partner.ImageUrl = PartnerEdit.ImageUrl;
                }
                else
                {
                    var deleteImg = await _imageUploader.RemoveImageAsync(PartnerEdit.PublicId);
                    var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "Partner");
                    Partner.PublicId = resImageUploader.PublicId;
                    Partner.ImageUrl = resImageUploader.Url;
                }
                Partner.PartnerId = id;
                var res = await _PartnerService.UpdatePartnerAsync(id, Partner);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _PartnerService.GetPartnerByIdAsync(id));
        }

        // POST: PartnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PartnerDelete = await _PartnerService.DeletePartnerAsync(id);
                TempData["SuccessMessage"] = "Xóa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetPartnersByType(int id)
        {
            return PartialView(await _PartnerService.GetPartnersByType(id));
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
