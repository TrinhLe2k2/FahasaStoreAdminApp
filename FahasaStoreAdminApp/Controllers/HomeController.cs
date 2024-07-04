using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.CustomModels;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly IUserService _userService;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;
        private readonly UserLogined _userLogined;
        private readonly IAccountService _accountService;
        private readonly IImageUploader _imageUploader;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IJwtTokenDecoder jwtTokenDecoder, IUserService userService, UserLogined userLogined, IAccountService accountService, IImageUploader imageUploader)
        {
            _logger = logger;
            _homeService = homeService;
            _jwtTokenDecoder = jwtTokenDecoder;
            _userService = userService;
            _userLogined = userLogined;
            _accountService = accountService;
            _imageUploader = imageUploader;
        }

        [Authorize(AppRole.Admin, AppRole.Staff )]
        public async Task<ActionResult> Index(int? year)
        {
            var statistics = await _homeService.GetYearlyStatistics(year);
            return View(statistics);
        }

        [Authorize(AppRole.Admin)]
        public async Task<ActionResult> Website()
        {
            try
            {
                var webEdit = await _homeService.GetWebsiteByIdAsync();
                return View(webEdit);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AppRole.Admin)]
        public async Task<ActionResult> Website(Website model, IFormFile? LogoUrlImg, IFormFile? IconUrlImg)
        {
            try
            {
                var webEdit = await _homeService.GetWebsiteByIdAsync();
                webEdit.Name = model.Name;
                webEdit.Description = model.Description;
                webEdit.Address = model.Address;
                webEdit.Phone = model.Phone;
                webEdit.Email = model.Email;

                if (LogoUrlImg != null && LogoUrlImg.Length > 0)
                {
                    var isDeleteImg = await _imageUploader.RemoveImageAsync(webEdit.LogoUrl);
                    var resImgUploader = await _imageUploader.UploadImageAsync(LogoUrlImg, "LogoImg");
                    webEdit.LogoUrl = resImgUploader.Url;
                }

                if (IconUrlImg != null && IconUrlImg.Length > 0)
                {
                    var isDeleteImg = await _imageUploader.RemoveImageAsync(webEdit.LogoUrl);
                    var resImgUploader = await _imageUploader.UploadImageAsync(IconUrlImg, "IconImg");
                    webEdit.IconUrl = resImgUploader.Url;
                }

                var res = await _homeService.UpdateWebsite(webEdit);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return RedirectToAction("Website");
            }
            catch
            {
                TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong khi cập nhật dữ liệu";
                return View();
            }
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public async Task<ActionResult> Account()
        {
            var user = await _userService.GetByIdAsync(_userLogined.CurrentUser?.Id ?? "");
            return View(user);
        }
    }
}
