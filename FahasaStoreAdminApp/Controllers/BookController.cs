using FahasaStoreAdminApp.DataTemp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult Index()
        {
            return View(new BookData().ListBooks());
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return PartialView(new BookData().Book(id));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewData["SubcategoryId"] = new SelectList(new SubcategoryData().ListSubcategorys(), "SubcategoryId", "Name");
            ViewData["PartnerId"] = new SelectList(new PartnerData().ListPartners(), "PartnerId", "Name");
            ViewData["AuthorId"] = new SelectList(new AuthorData().ListAuthors(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(new CoverTypeData().ListCoverTypes(), "CoverTypeId", "TypeName");
            ViewData["DimensionId"] = new SelectList(new DimensionData().ListDimensions().Select(d => new {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            }), "DimensionId", "DisplayText");

            return PartialView();
        }

        // POST: BookController/Create
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["SubcategoryId"] = new SelectList(new SubcategoryData().ListSubcategorys(), "SubcategoryId", "Name");
            ViewData["PartnerId"] = new SelectList(new PartnerData().ListPartners(), "PartnerId", "Name");
            ViewData["AuthorId"] = new SelectList(new AuthorData().ListAuthors(), "AuthorId", "Name");
            ViewData["CoverTypeId"] = new SelectList(new CoverTypeData().ListCoverTypes(), "CoverTypeId", "TypeName");
            ViewData["DimensionId"] = new SelectList(new DimensionData().ListDimensions().Select(d => new {
                DimensionId = d.DimensionId,
                DisplayText = $"{d.Length} x {d.Width} x {d.Height}"
            }), "DimensionId", "DisplayText");
            return PartialView(new BookData().Book(id));
        }

        // POST: BookController/Edit/5
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

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return PartialView(new BookData().Book(id));
        }

        // POST: BookController/Delete/5
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
