using FahasaStoreAdminApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Website()
        {
            return View();
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
