using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class CoverTypeController : Controller
    {
        // GET: CoverTypeController
        public ActionResult Index()
        {
            return View(new CoverTypeData().ListCoverTypes());
        }

        // GET: CoverTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoverTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CoverTypeController/Create
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

        // GET: CoverTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(new CoverTypeData().CoverType(id));
        }

        // POST: CoverTypeController/Edit/5
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

        // GET: CoverTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new CoverTypeData().CoverType(id));
        }

        // POST: CoverTypeController/Delete/5
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
