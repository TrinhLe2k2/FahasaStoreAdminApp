using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.CustomModels;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        private readonly IJwtTokenDecoder _jwtTokenDecoder;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService, IJwtTokenDecoder jwtTokenDecoder)
        {
            _logger = logger;
            _homeService = homeService;
            _jwtTokenDecoder = jwtTokenDecoder;
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
        public IActionResult Account()
        {
            return View();
        }
    }
}
