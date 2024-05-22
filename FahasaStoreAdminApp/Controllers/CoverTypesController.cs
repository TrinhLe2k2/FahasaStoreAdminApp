using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class CoverTypesController : Controller
    {
        private readonly ICoverTypeService _CoverTypeService;
        private readonly IMapper _mapper;
        public CoverTypesController(ICoverTypeService CoverTypeService, IMapper mapper)
        {
            _CoverTypeService = CoverTypeService;
            _mapper = mapper;
        }

        // GET: CoverTypeController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _CoverTypeService.GetCoverTypesAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: CoverTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _CoverTypeService.GetCoverTypeByIdAsync(id));
        }

        // GET: CoverTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CoverTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CoverType CoverType)
        {
            try
            {
                var res = await _CoverTypeService.AddCoverTypeAsync(CoverType);
                TempData["SuccessMessage"] = "Thêm mới thành công";
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
            return PartialView(await _CoverTypeService.GetCoverTypeByIdAsync(id));
        }

        // POST: CoverTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CoverType CoverType)
        {
            try
            {
                CoverType.CoverTypeId = id;
                var res = await _CoverTypeService.UpdateCoverTypeAsync(id, CoverType);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
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
            return PartialView(await _CoverTypeService.GetCoverTypeByIdAsync(id));
        }

        // POST: CoverTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var CoverTypeDelete = await _CoverTypeService.DeleteCoverTypeAsync(id);
                TempData["SuccessMessage"] = "Xóa thành công";
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
