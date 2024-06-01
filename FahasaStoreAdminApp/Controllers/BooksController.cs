using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FahasaStoreAdminApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ISubcategoryService _subcategoryService;
        private readonly IPartnerService _partnerervice;
        private readonly IAuthorService _authorService;
        private readonly ICoverTypeService _coverTypeService;
        private readonly IDimensionService _dimensionService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper, ISubcategoryService subcategoryService, IPartnerService partnerService,
            IAuthorService authorService, ICoverTypeService coverTypeService, IDimensionService dimensionService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _subcategoryService = subcategoryService;
            _partnerervice = partnerService;
            _authorService = authorService;
            _coverTypeService = coverTypeService;
            _dimensionService = dimensionService;
        }

        // GET: BookController
        public async Task<ActionResult> Index(int? page)
        {
            try
            {
                if (page < 0) page = 1;
                var data = await _bookService.GetBooksPagination(page, 1);

                if (page > data.PageCount)
                {
                    data = await _bookService.GetBooksPagination(data.PageCount, 1);
                }

                // Calculate pagination details
                int pageNumber = data.PageNumber;
                int pageCount = data.PageCount;

                int startPage = Math.Max(1, pageNumber - 3);
                int endPage = Math.Min(pageCount, pageNumber + 3);

                data.StartPage = startPage;
                data.EndPage = endPage;

                ViewData["PageData"] = data;
                return View(data.books);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _bookService.GetBookByIdAsync(id));
        }

        // GET: BookController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["SubcategoryId"] = new SelectList(await _subcategoryService.GetSubcategoriesAsync(), "SubcategoryId", "Name");
            ViewData["AuthorId"] = new SelectList(await _authorService.GetAuthorsAsync(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(await _coverTypeService.GetCoverTypesAsync(), "CoverTypeId", "TypeName");

            var dimensions = await _dimensionService.GetDimensionsAsync();
            var dimensionSelectList = dimensions.Select(d => new
            {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["DimensionId"] = new SelectList(dimensionSelectList, "DimensionId", "DisplayText");

            return PartialView();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            try
            {
                var res = await _bookService.AddBookAsync(book);
                TempData["ActiveID"] = res;
                TempData["SuccessMessage"] = "Thêm mới thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["SubcategoryId"] = new SelectList(await _subcategoryService.GetSubcategoriesAsync(), "SubcategoryId", "Name");
            ViewData["AuthorId"] = new SelectList(await _authorService.GetAuthorsAsync(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(await _coverTypeService.GetCoverTypesAsync(), "CoverTypeId", "TypeName");

            var dimensions = await _dimensionService.GetDimensionsAsync();
            var dimensionSelectList = dimensions.Select(d => new
            {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            });
            ViewData["DimensionId"] = new SelectList(dimensionSelectList, "DimensionId", "DisplayText");
            return PartialView(await _bookService.GetBookByIdAsync(id));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Book book)
        {
            try
            {
                book.BookId = id;
                var res = await _bookService.UpdateBookAsync(id, book);
                TempData["ActiveID"] = res;
                TempData["SuccessMessage"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _bookService.GetBookByIdAsync(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var bookDelete = await _bookService.DeleteBookAsync(id);
                TempData["SuccessMessage"] = "Xóa thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetPosterImages(int id)
        {
            ViewData["BookID"] = id;
            return PartialView(await _bookService.GetPosterImagesAsync(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
