using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            return View();
        }

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
        public async Task<ActionResult> Website(Website Website)
        {
            try
            {
                Website.WebsiteId = 1;
                var res = await _homeService.UpdateWebsite(Website);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Account()
        {
            return View();
        }

        public IActionResult ConfirmDelete(int id, string url, string name)
        {
            ViewData["Url"] = url;
            ViewData["Name"] = name;
            ViewData["Id"] = id;
            return PartialView("/Views/Partial/_ConfirmDelete.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
