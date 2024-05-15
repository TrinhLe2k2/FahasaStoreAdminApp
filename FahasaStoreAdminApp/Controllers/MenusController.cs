using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class MenusController : Controller
    {
        private readonly IMenuService _MenuService;
        private readonly IMapper _mapper;
        public MenusController(IMenuService MenuService, IMapper mapper)
        {
            _MenuService = MenuService;
            _mapper = mapper;
        }

        // GET: MenuController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _MenuService.GetMenusAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: MenuController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Menu Menu)
        {
            try
            {
                if (Menu.ImageUrl == null)
                {
                    Menu.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
                }
                var res = await _MenuService.AddMenuAsync(Menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Menu Menu)
        {
            try
            {
                Menu.MenuId = id;
                var res = await _MenuService.UpdateMenuAsync(id, Menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView(await _MenuService.GetMenuByIdAsync(id));
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var MenuDelete = await _MenuService.DeleteMenuAsync(id);
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
