using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class BannerController : Controller
    {
        // GET: BannerController
        public ActionResult Index()
        {
            return View(new BannerData().ListBanners());
        }

        // GET: BannerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BannerController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: BannerController/Create
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

        // GET: BannerController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(new BannerData().Banner(id));
        }

        // POST: BannerController/Edit/5
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

        // GET: BannerController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new BannerData().Banner(id));
        }

        // POST: BannerController/Delete/5
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
