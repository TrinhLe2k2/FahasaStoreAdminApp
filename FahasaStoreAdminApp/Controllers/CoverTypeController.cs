using AutoMapper;
using FahasaStoreAdminApp.DataTemp;
using FahasaStoreAdminApp.Interfaces;
using FahasaStoreAdminApp.Models;
using FahasaStoreAPI.Models.FormModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeService _CoverTypeService;
        private readonly IMapper _mapper;
        public CoverTypeController(ICoverTypeService CoverTypeService, IMapper mapper)
        {
            _CoverTypeService = CoverTypeService;
            _mapper = mapper;
        }

        // GET: CoverTypeController
        public async Task<ActionResult> Index()
        {
            try
            {
                var CoverTypes = await _CoverTypeService.GetCoverTypesAsync();
                return View(CoverTypes);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: CoverTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var CoverType = await _CoverTypeService.GetCoverTypeByIdAsync(id);
            return PartialView(CoverType);
        }

        // GET: CoverTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CoverTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CoverTypeForm CoverTypeForm)
        {
            try
            {
                var res = await _CoverTypeService.AddCoverTypeAsync(CoverTypeForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoverTypeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var CoverType = await _CoverTypeService.GetCoverTypeByIdAsync(id);
            return PartialView(_mapper.Map<CoverTypeForm>(CoverType));
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CoverTypeForm CoverTypeForm)
        {
            try
            {
                CoverTypeForm.CoverTypeId = id;
                var res = await _CoverTypeService.UpdateCoverTypeAsync(id, CoverTypeForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoverTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var CoverType = await _CoverTypeService.GetCoverTypeByIdAsync(id);
            return PartialView(_mapper.Map<CoverTypeForm>(CoverType));
        }

        // POST: CoverTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var CoverTypeDelete = await _CoverTypeService.DeleteCoverTypeAsync(id);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
