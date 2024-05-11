using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class DimensionController : Controller
    {
        // GET: DimensionController
        public ActionResult Index()
        {
            return View(new DimensionData().ListDimensions());
        }

        // GET: DimensionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DimensionController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: DimensionController/Create
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

        // GET: DimensionController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(new DimensionData().Dimension(id));
        }

        // POST: DimensionController/Edit/5
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

        // GET: DimensionController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new DimensionData().Dimension(id));
        }

        // POST: DimensionController/Delete/5
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
