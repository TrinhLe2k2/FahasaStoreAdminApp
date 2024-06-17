using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Filters;

namespace FahasaStoreAdminApp.Controllers
{
    public class FlashSaleBooksController : GenericController<FlashSaleBook, FlashSaleBookModel, FlashSaleBookDTO, int>
    {
        private readonly IFlashSaleService _FlashSaleService;
        private readonly IFlashSaleBookService _FlashSaleBookService;
        private readonly IBookService _BookService;
        public FlashSaleBooksController(IFlashSaleService flashSaleService, IFlashSaleBookService flashSaleBookService, IBookService bookService, IMapper mapper, IImageUploader imageUploader) : base(flashSaleBookService, mapper, imageUploader)
        {
            _FlashSaleService = flashSaleService;
            _FlashSaleBookService = flashSaleBookService;
            _BookService = bookService;
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<IActionResult> Index(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            ViewData["FlashSales"] = await _FlashSaleService.GetAllAsync();
            return await base.Index(filters, sortField, sortDirection, page, size);
        }

        [Authorize(AppRole.Admin)]
        public override async Task<ActionResult> Create()
        {
            var FlashSales = await _FlashSaleService.GetAllAsync();
            var FlashSaleSelectList = FlashSales.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.StartDate.ToString("dd/MM/yyyy")} - {d.EndDate.ToString("dd/MM/yyyy")}"
            });
            ViewData["FlashSales"] = new SelectList(FlashSaleSelectList, "Id", "DisplayText");
            ViewData["Books"] = new SelectList(await _BookService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

        [Authorize(AppRole.Admin)]
        public override async Task<IActionResult> Edit(int id)
        {
            var FlashSales = await _FlashSaleService.GetAllAsync();
            var FlashSaleSelectList = FlashSales.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.StartDate} - {d.EndDate}"
            });
            ViewData["FlashSales"] = new SelectList(FlashSaleSelectList, "Id", "DisplayText");
            ViewData["Books"] = new SelectList(await _BookService.GetAllAsync(), "Id", "Name");
            return await base.Edit(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public async Task<ActionResult> GetFlashSaleBooksByFlashSale(string id)
        {
            return PartialView(await _FlashSaleBookService.GetListByAsync("FlashSaleId", id));
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

    }
}
