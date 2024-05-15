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
        public BannersController(IBannerService BannerService)
        {
            _BannerService = BannerService;
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
        public async Task<ActionResult> Create(Banner Banner)
        {
            try
            {
                if (Banner.ImageUrl == null)
                {
                    Banner.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
                }
                Banner.CreatedAt = DateTime.Now;
                var res = await _BannerService.AddBannerAsync(Banner);
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
        public async Task<ActionResult> Edit(int id, Banner Banner)
        {
            try
            {
                var bannerEdit = await _BannerService.GetBannerByIdAsync(id);
                Banner.BannerId = id;
                Banner.CreatedAt = bannerEdit.CreatedAt;
                var res = await _BannerService.UpdateBannerAsync(id, Banner);
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
                var BannerDelete = await _BannerService.DeleteBannerAsync(id);
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
