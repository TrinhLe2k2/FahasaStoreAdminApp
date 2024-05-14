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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _AuthorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService AuthorService, IMapper mapper)
        {
            _AuthorService = AuthorService;
            _mapper = mapper;
        }

        // GET: AuthorController
        public async Task<ActionResult> Index()
        {
            try
            {
                var Authors = await _AuthorService.GetAuthorsAsync();
                return View(Authors);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: AuthorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Author = await _AuthorService.GetAuthorByIdAsync(id);
            return PartialView(Author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorForm AuthorForm)
        {
            try
            {
                var res = await _AuthorService.AddAuthorAsync(AuthorForm);
                TempData["ActiveID"] = res;
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
            var Author = await _AuthorService.GetAuthorByIdAsync(id);
            return PartialView(_mapper.Map<AuthorForm>(Author));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AuthorForm AuthorForm)
        {
            try
            {
                AuthorForm.AuthorId = id;
                var res = await _AuthorService.UpdateAuthorAsync(id, AuthorForm);
                TempData["ActiveID"] = res;
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
            var Author = await _AuthorService.GetAuthorByIdAsync(id);
            return PartialView(_mapper.Map<AuthorForm>(Author));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var AuthorDelete = await _AuthorService.DeleteAuthorAsync(id);
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
