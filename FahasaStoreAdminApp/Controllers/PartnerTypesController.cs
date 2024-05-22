using AutoMapper;
using FahasaStoreAdminApp.Models;
using FahasaStoreAdminApp.Services;
using FahasaStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnerTypesController : Controller
    {
        private readonly IPartnerTypeService _PartnerTypeService;
        private readonly IMapper _mapper;
        public PartnerTypesController(IPartnerTypeService PartnerTypeService, IMapper mapper)
        {
            _PartnerTypeService = PartnerTypeService;
            _mapper = mapper;
        }

        // GET: PartnerTypeController
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await _PartnerTypeService.GetPartnerTypesAsync());
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: PartnerTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return PartialView(await _PartnerTypeService.GetPartnerTypeByIdAsync(id));
        }

        // GET: PartnerTypeController/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: PartnerTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PartnerType PartnerType)
        {
            try
            {
                var res = await _PartnerTypeService.AddPartnerTypeAsync(PartnerType);
                TempData["SuccessMessage"] = "Thêm mới thành công";
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
            return PartialView(await _PartnerTypeService.GetPartnerTypeByIdAsync(id));
        }

        // POST: PartnerTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PartnerType PartnerType)
        {
            try
            {
                PartnerType.PartnerTypeId = id;
                var res = await _PartnerTypeService.UpdatePartnerTypeAsync(id, PartnerType);
                TempData["SuccessMessage"] = "Chỉnh sửa thành công";
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
            return PartialView(await _PartnerTypeService.GetPartnerTypeByIdAsync(id));
        }

        // POST: PartnerTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var PartnerTypeDelete = await _PartnerTypeService.DeletePartnerTypeAsync(id);
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
            var errorMessage = TempData["ErrorMessage"] as string;
            ViewBag.ErrorMessage = errorMessage;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
