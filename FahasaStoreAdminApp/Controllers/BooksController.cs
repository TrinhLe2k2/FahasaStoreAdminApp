using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class BooksController : GenericController<Book, BookModel, BookDTO, int>
    {
        private readonly IBookService _bookService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IAuthorService _authorService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IDimensionService _dimensionService;
        private readonly IPosterImageService _posterImageService;
        #region Constructor
        public BooksController(
            IBookService bookService, 
            ISubcategoryService subcategoryService, 
            IAuthorService authorService, 
            ICoverTypeService coverTypeService, 
            IDimensionService dimensionService, 
            IImageUploader imageUploader,
            IMapper mapper,
            IPosterImageService posterImageService
            ) : base(bookService, mapper, imageUploader)

        {
            _bookService = bookService;
            _subcategoryService = subcategoryService;
            _authorService = authorService;
            _coverTypeService = coverTypeService;
            _dimensionService = dimensionService;
            _posterImageService = posterImageService;
        }
        #endregion

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<ActionResult> Create()
        {
            ViewData["SubcategoryId"] = new SelectList(await _subcategoryService.GetAllAsync(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(await _authorService.GetAllAsync(), "Id", "Name");
            ViewData["CoverTypeId"] = new SelectList(await _coverTypeService.GetAllAsync(), "Id", "TypeName");

            var dimensions = await _dimensionService.GetAllAsync();
            var dimensionSelectList = dimensions.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["DimensionId"] = new SelectList(dimensionSelectList, "Id", "DisplayText");
            return PartialView();
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["SubcategoryId"] = new SelectList(await _subcategoryService.GetAllAsync(), "Id", "Name");
            ViewData["AuthorId"] = new SelectList(await _authorService.GetAllAsync(), "Id", "Name");
            ViewData["CoverTypeId"] = new SelectList(await _coverTypeService.GetAllAsync(), "Id", "TypeName");

            var dimensions = await _dimensionService.GetAllAsync();
            var dimensionSelectList = dimensions.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["DimensionId"] = new SelectList(dimensionSelectList, "Id", "DisplayText");
            var editEntity = await _bookService.GetItemUpdateByIdAsync(id);
            return PartialView(editEntity);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public async Task<ActionResult> GetPosterImages(string id)
        {
            ViewData["BookID"] = id;
            var listPoster = await _posterImageService.GetListByAsync("BookId", id);
            return PartialView(listPoster.Items);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Index(Dictionary<string, string>? filters, string? sortField, string? sortDirection, int page = 1, int size = 10)
        {
            return base.Index(filters, sortField, sortDirection, page, size);
        }
    }
}
