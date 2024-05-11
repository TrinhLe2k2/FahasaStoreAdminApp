using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnerTypeController : Controller
    {
        // GET: PartnerTypeController
        public ActionResult Index()
        {
            return View(new PartnerTypeData().ListPartnerTypes());
        }

        // GET: PartnerTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartnerTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: PartnerTypeController/Create
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

        // GET: PartnerTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(new PartnerTypeData().PartnerType(id));
        }

        // POST: PartnerTypeController/Edit/5
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

        // GET: PartnerTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new PartnerTypeData().PartnerType(id));
        }

        // POST: PartnerTypeController/Delete/5
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
