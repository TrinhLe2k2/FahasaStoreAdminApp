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
    public class PartnerTypeController : Controller
    {
        private readonly IPartnerTypeService _PartnerTypeService;
        private readonly IMapper _mapper;
        public PartnerTypeController(IPartnerTypeService PartnerTypeService, IMapper mapper)
        {
            _PartnerTypeService = PartnerTypeService;
            _mapper = mapper;
        }

        // GET: PartnerTypeController
        public async Task<ActionResult> Index()
        {
            try
            {
                var PartnerTypes = await _PartnerTypeService.GetPartnerTypesAsync();
                return View(PartnerTypes);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var PartnerType = await _PartnerTypeService.GetPartnerTypeByIdAsync(id);
            return PartialView(PartnerType);
        }

        // GET: PartnerTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: PartnerTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PartnerTypeForm PartnerTypeForm)
        {
            try
            {
                var res = await _PartnerTypeService.AddPartnerTypeAsync(PartnerTypeForm);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var PartnerType = await _PartnerTypeService.GetPartnerTypeByIdAsync(id);
            return PartialView(_mapper.Map<PartnerTypeForm>(PartnerType));
        }

        // POST: PartnerTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PartnerTypeForm PartnerTypeForm)
        {
            try
            {
                PartnerTypeForm.PartnerTypeId = id;
                var res = await _PartnerTypeService.UpdatePartnerTypeAsync(id, PartnerTypeForm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartnerTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var PartnerType = await _PartnerTypeService.GetPartnerTypeByIdAsync(id);
            return PartialView(_mapper.Map<PartnerTypeForm>(PartnerType));
        }

        // POST: PartnerTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PartnerTypeDelete = await _PartnerTypeService.DeletePartnerTypeAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
