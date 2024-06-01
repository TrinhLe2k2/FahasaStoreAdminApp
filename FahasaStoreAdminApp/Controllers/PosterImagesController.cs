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

        // POST: PosterImageController/Delete/5
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
            try
            {
                var poster = await _posterImageService.GetPosterImageByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(poster.PublicId);
                var PosterImageDelete = await _posterImageService.DeletePosterImageAsync(id);
                return Json(new { status = "success" });
            }
            catch
            {
                return View();
            }
        }
    }
}
