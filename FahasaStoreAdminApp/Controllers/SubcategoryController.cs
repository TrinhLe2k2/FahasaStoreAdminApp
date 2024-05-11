using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: SubcategoryController
        public ActionResult Index()
        {
            return View(new SubcategoryData().ListSubcategorys());
        }

        // GET: SubcategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubcategoryController/Create
        public ActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(new CategoryData().ListCategorys(), "CategoryId", "Name");
            return PartialView();
        }

        // POST: SubcategoryController/Create
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

        // GET: SubcategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["CategoryId"] = new SelectList(new CategoryData().ListCategorys(), "CategoryId", "Name");
            return PartialView(new SubcategoryData().Subcategory(id));
        }

        // POST: SubcategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: SubcategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new SubcategoryData().Subcategory(id));
        }

        // POST: SubcategoryController/Delete/5
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
