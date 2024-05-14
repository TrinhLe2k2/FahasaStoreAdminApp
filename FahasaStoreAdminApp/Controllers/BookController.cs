using AutoMapper;
using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAdminApp.Models;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: BookController
        public async Task<ActionResult> Index()
        {
            try
            {
                var books = await _bookService.GetBooksAsync();
                return View(books);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: BookController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return PartialView(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewData["SubcategoryId"] = new SelectList(new SubcategoryData().ListSubcategorys(), "SubcategoryId", "Name");
            ViewData["PartnerId"] = new SelectList(new PartnerData().ListPartners(), "PartnerId", "Name");
            //ViewData["AuthorId"] = new SelectList(new AuthorData().ListAuthors(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(new CoverTypeData().ListCoverTypes(), "CoverTypeId", "TypeName");
            ViewData["DimensionId"] = new SelectList(new DimensionData().ListDimensions().Select(d => new {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            }), "DimensionId", "DisplayText");

            return PartialView();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookForm bookForm)
        {
            try
            {
                var res = await _bookService.AddBookAsync(bookForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["SubcategoryId"] = new SelectList(new SubcategoryData().ListSubcategorys(), "SubcategoryId", "Name");
            ViewData["PartnerId"] = new SelectList(new PartnerData().ListPartners(), "PartnerId", "Name");
            //ViewData["AuthorId"] = new SelectList(new AuthorData().ListAuthors(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(new CoverTypeData().ListCoverTypes(), "CoverTypeId", "TypeName");
            ViewData["DimensionId"] = new SelectList(new DimensionData().ListDimensions().Select(d => new {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            }), "DimensionId", "DisplayText");

            var book = await _bookService.GetBookByIdAsync(id);
            return PartialView(_mapper.Map<BookForm>(book));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, BookForm bookForm)
        {
            try
            {
                bookForm.BookId = id;
                var res = await _bookService.UpdateBookAsync(id, bookForm);
                TempData["ActiveID"] = res;
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
            var book = await _bookService.GetBookByIdAsync(id);
            return PartialView(_mapper.Map<BookForm>(book));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var bookDelete = await _bookService.DeleteBookAsync(id);
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
