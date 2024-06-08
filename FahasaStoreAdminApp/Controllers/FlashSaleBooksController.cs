using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class FlashSaleBooksController : GenericController<FlashSaleBook, FlashSaleBookModel, int>
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

        public override async Task<IActionResult> Index()
        {
            var FlashSales = await _FlashSaleService.GetAllAsync();
            var FlashSaleSelectList = FlashSales.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.StartDate} - {d.EndDate}"
            });
            ViewData["FlashSales"] = new SelectList(FlashSaleSelectList, "Id", "DisplayText");
            ViewData["Books"] = new SelectList(await _BookService.GetAllAsync(), "Id", "Name");
            return await base.Index();
        }

        public override async Task<ActionResult> Create()
        {
            var FlashSales = await _FlashSaleService.GetAllAsync();
            var FlashSaleSelectList = FlashSales.Select(d => new
            {
                Id = d.Id,
                DisplayText = $"{d.StartDate} - {d.EndDate}"
            });
            ViewData["FlashSales"] = new SelectList(FlashSaleSelectList, "Id", "DisplayText");
            ViewData["Books"] = new SelectList(await _BookService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

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

        public async Task<ActionResult> GetFlashSaleBooksByFlashSale(string id)
        {
            return PartialView(await _FlashSaleBookService.GetListByAsync("FlashSaleId", id));
        }
    }
}
