using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.CustomModels;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IJwtTokenDecoder jwtTokenDecoder, IUserService userService, UserLogined userLogined, IAccountService accountService)
        {
            _logger = logger;
            _homeService = homeService;
            _jwtTokenDecoder = jwtTokenDecoder;
            _userService = userService;
            _userLogined = userLogined;
            _accountService = accountService;
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
                return View(await _homeService.GetWebsiteByIdAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AppRole.Admin)]
        public async Task<ActionResult> Website(WebsiteModel Website)
        {
            try
            {
                Website.Id = 1;
                var res = await _homeService.UpdateWebsite(Website);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return View();
            }
            catch
            {
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
