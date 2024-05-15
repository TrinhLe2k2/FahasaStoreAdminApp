using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class DimensionsController : Controller
    {
        private readonly IDimensionService _DimensionService;
        private readonly IMapper _mapper;
        public DimensionsController(IDimensionService DimensionService, IMapper mapper)
        {
            _DimensionService = DimensionService;
            _mapper = mapper;
        }

        // GET: DimensionController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _DimensionService.GetDimensionsAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: DimensionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _DimensionService.GetDimensionByIdAsync(id));
        }

        // GET: DimensionController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: DimensionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Dimension Dimension)
        {
            try
            {
                var res = await _DimensionService.AddDimensionAsync(Dimension);
                
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
            return PartialView(await _DimensionService.GetDimensionByIdAsync(id));
        }

        // POST: DimensionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Dimension Dimension)
        {
            try
            {
                Dimension.DimensionId = id;
                var res = await _DimensionService.UpdateDimensionAsync(id, Dimension);
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
            return PartialView(await _DimensionService.GetDimensionByIdAsync(id));
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
