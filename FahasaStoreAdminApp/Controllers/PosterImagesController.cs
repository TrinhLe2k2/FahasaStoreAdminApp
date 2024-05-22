using BookStoreAPI.Services;
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
        private readonly IImageUploader _imageUploader;
        public PosterImagesController(IPosterImageService posterImageService, IImageUploader imageUploader)
        {
            _posterImageService = posterImageService;
            _imageUploader = imageUploader;
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
        public ActionResult Create(int id)
        {
            return PartialView();
        }

        // POST: PosterImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id, IFormFile fileImage)
        {
            try
            {
                var resImageUploader = await _imageUploader.UploadImageAsync(fileImage, "BookPoster");
                var PosterImage = new PosterImage();
                PosterImage.BookId = id;
                PosterImage.PublicId = resImageUploader.PublicId;
                PosterImage.ImageUrl = resImageUploader.Url;

                var res = await _posterImageService.AddPosterImageAsync(PosterImage);
                return Json(new { imageUrl = PosterImage.ImageUrl, imgId = res });
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
                PosterImage.PosterImageId = id;
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
            ViewData["PosterImage"] = await _posterImageService.GetPosterImageByIdAsync(id);
            return PartialView();
        }

        // POST: PosterImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PosterImageDelete = await _posterImageService.DeletePosterImageAsync(id);
                return Json(new { status = "success" });
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
