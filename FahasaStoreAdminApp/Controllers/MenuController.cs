using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class MenuController : Controller
    {
        // GET: MenuController
        public ActionResult Index()
        {
            var listMenu = new MenuData().ListMenus();
            return View(listMenu);
        }

        // GET: MenuController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var menu = new MenuData().Menu(id);
            return PartialView(menu);
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MenuForm menuForm)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public ActionResult Delete(int id)
        {
            var menu = new MenuData().Menu(id);
            return PartialView(menu);
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
