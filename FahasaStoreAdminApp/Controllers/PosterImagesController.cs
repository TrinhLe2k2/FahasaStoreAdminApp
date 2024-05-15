using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class PosterImagesController : Controller
    {
        private readonly IPosterImageService _posterImageService;
        public PosterImagesController(IPosterImageService posterImageService)
        {
            _posterImageService = posterImageService;
        }

        // GET: PosterImageController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _posterImageService.GetPosterImagesAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PosterImageController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _posterImageService.GetPosterImageByIdAsync(id));
        }

        // GET: PosterImageController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: PosterImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PosterImage PosterImage)
        {
            try
            {
                var res = await _posterImageService.AddPosterImageAsync(PosterImage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosterImageController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _posterImageService.GetPosterImageByIdAsync(id));
        }

        // POST: PosterImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PosterImage PosterImage)
        {
            try
            {
                PosterImage.PosterImgageId = id;
                var res = await _posterImageService.UpdatePosterImageAsync(id, PosterImage);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosterImageController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _posterImageService.GetPosterImageByIdAsync(id));
        }

        // POST: PosterImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PosterImageDelete = await _posterImageService.DeletePosterImageAsync(id);
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
