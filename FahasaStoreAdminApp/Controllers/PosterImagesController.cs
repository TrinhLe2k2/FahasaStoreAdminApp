using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                var PosterImage = new PosterImageModel();
                PosterImage.BookId = id;
                PosterImage.PublicId = resImageUploader.PublicId;
                PosterImage.ImageUrl = resImageUploader.Url;

                var res = await _posterImageService.AddAsync(PosterImage);
                return Json(new { imageUrl = PosterImage.ImageUrl, imgId = res });
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
                var poster = await _posterImageService.GetByIdAsync(id);
                var deleteImg = await _imageUploader.RemoveImageAsync(poster.PublicId);
                var PosterImageDelete = await _posterImageService.DeleteAsync(id);
                return Json(new { status = "success" });
            }
            catch
            {
                return View();
            }
        }
    }
}
