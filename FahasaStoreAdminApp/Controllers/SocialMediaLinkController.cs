using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class SocialMediaLinkController : Controller
    {
        // GET: SocialMediaLinkController
        public ActionResult Index()
        {
            return View(new SocialMediaLinkData().ListSocialMediaLinks());
        }

        // GET: SocialMediaLinkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SocialMediaLinkController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: SocialMediaLinkController/Create
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

        // GET: SocialMediaLinkController/Edit/5
        public ActionResult Edit(int id)
        {
            return PartialView(new SocialMediaLinkData().SocialMediaLink(id));
        }

        // POST: SocialMediaLinkController/Edit/5
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

        // GET: SocialMediaLinkController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new SocialMediaLinkData().SocialMediaLink(id));
        }

        // POST: SocialMediaLinkController/Delete/5
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
