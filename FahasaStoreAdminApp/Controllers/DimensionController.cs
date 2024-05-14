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
    public class DimensionController : Controller
    {
        private readonly IDimensionService _DimensionService;
        private readonly IMapper _mapper;
        public DimensionController(IDimensionService DimensionService, IMapper mapper)
        {
            _DimensionService = DimensionService;
            _mapper = mapper;
        }

        // GET: DimensionController
        public async Task<ActionResult> Index()
        {
            try
            {
                var Dimensions = await _DimensionService.GetDimensionsAsync();
                return View(Dimensions);
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: DimensionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var Dimension = await _DimensionService.GetDimensionByIdAsync(id);
            return PartialView(Dimension);
        }

        // GET: DimensionController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: DimensionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DimensionForm DimensionForm)
        {
            try
            {
                var res = await _DimensionService.AddDimensionAsync(DimensionForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DimensionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var Dimension = await _DimensionService.GetDimensionByIdAsync(id);
            return PartialView(_mapper.Map<DimensionForm>(Dimension));
        }

        // POST: DimensionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DimensionForm DimensionForm)
        {
            try
            {
                DimensionForm.DimensionId = id;
                var res = await _DimensionService.UpdateDimensionAsync(id, DimensionForm);
                TempData["ActiveID"] = res;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DimensionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var Dimension = await _DimensionService.GetDimensionByIdAsync(id);
            return PartialView(_mapper.Map<DimensionForm>(Dimension));
        }

        // POST: DimensionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var DimensionDelete = await _DimensionService.DeleteDimensionAsync(id);
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
