using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnerController : Controller
    {
        // GET: PartnerController
        public ActionResult Index()
        {
            return View(new PartnerData().ListPartners());
        }

        // GET: PartnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartnerController/Create
        public ActionResult Create()
        {
            ViewData["PartnerTypeId"] = new SelectList(new PartnerTypeData().ListPartnerTypes(), "PartnerTypeId", "Name");
            return PartialView();
        }

        // POST: PartnerController/Create
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

        // GET: PartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["PartnerTypeId"] = new SelectList(new PartnerTypeData().ListPartnerTypes(), "PartnerTypeId", "Name");
            return PartialView(new PartnerData().Partner(id));
        }

        // POST: PartnerController/Edit/5
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

        // GET: PartnerController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new PartnerData().Partner(id));
        }

        // POST: PartnerController/Delete/5
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
