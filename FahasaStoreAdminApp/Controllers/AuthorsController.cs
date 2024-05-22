using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _AuthorService;
        private readonly IMapper _mapper;
        public AuthorsController(IAuthorService AuthorService, IMapper mapper)
        {
            _AuthorService = AuthorService;
            _mapper = mapper;
        }

        // GET: AuthorController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _AuthorService.GetAuthorsAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: AuthorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _AuthorService.GetAuthorByIdAsync(id));
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Author Author)
        {
            try
            {
                var res = await _AuthorService.AddAuthorAsync(Author);
                TempData["SuccessMessage"] = "Đã thêm tác giả mới thành công: ";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _AuthorService.GetAuthorByIdAsync(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Author Author)
        {
            try
            {
                Author.AuthorId = id;
                var res = await _AuthorService.UpdateAuthorAsync(id, Author);
                TempData["SuccessMessage"] = "Đã cập nhật thành công:";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _AuthorService.GetAuthorByIdAsync(id));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var AuthorDelete = await _AuthorService.DeleteAuthorAsync(id);
                TempData["SuccessMessage"] = "Đã xóa thành công:";
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
