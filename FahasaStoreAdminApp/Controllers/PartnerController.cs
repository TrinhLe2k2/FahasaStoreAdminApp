using AutoMapper;
using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAdminApp.Models;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _PartnerService;
        private readonly IPartnerTypeService _PartnerTypeService;
        private readonly IMapper _mapper;
        public PartnerController(IPartnerService PartnerService, IMapper mapper, IPartnerTypeService PartnerTypeService)
        {
            _PartnerService = PartnerService;
            _mapper = mapper;
            _PartnerTypeService = PartnerTypeService;
        }

        // GET: PartnerController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewData["PartnerTypes"] = await _PartnerTypeService.GetPartnerTypesAsync();

                var Partners = await _PartnerService.GetPartnersAsync();
                return View(Partners);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Partner = await _PartnerService.GetPartnerByIdAsync(id);
            return PartialView(Partner);
        }

        // GET: PartnerController/Create
        public async Task<ActionResult> Create()
        {
            ViewData["PartnerTypes"] = new SelectList(await _PartnerTypeService.GetPartnerTypesAsync(), "PartnerTypeId", "Name");
            return PartialView();
        }

        // POST: PartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PartnerForm PartnerForm)
        {
            if (PartnerForm.ImageUrl == null)
            {
                PartnerForm.ImageUrl = "https://voduongngochoa.com/uploads/noimg.jpg";
            }
            try
            {
                var res = await _PartnerService.AddPartnerAsync(PartnerForm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ViewData["PartnerTypes"] = new SelectList(await _PartnerTypeService.GetPartnerTypesAsync(), "PartnerTypeId", "Name");
            var Partner = await _PartnerService.GetPartnerByIdAsync(id);
            return PartialView(_mapper.Map<PartnerForm>(Partner));
        }

        // POST: PartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PartnerForm PartnerForm)
        {
            try
            {
                PartnerForm.PartnerId = id;
                var res = await _PartnerService.UpdatePartnerAsync(id, PartnerForm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Partner = await _PartnerService.GetPartnerByIdAsync(id);
            return PartialView(_mapper.Map<PartnerForm>(Partner));
        }

        // POST: PartnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PartnerDelete = await _PartnerService.DeletePartnerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> GetPartnersByType(int id)
        {
            var Subcategories = await _PartnerService.GetPartnersByType(id);
            return PartialView(Subcategories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
