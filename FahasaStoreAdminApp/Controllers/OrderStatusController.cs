using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FahasaStoreAdminApp.Controllers
{
    public class OrderStatusController : GenericController<OrderStatus, OrderStatusModel, OrderStatusDTO, int>
    {
        private readonly IOrderStatusService _OrderStatusService;
        private readonly IStatusService _statusService;
        public OrderStatusController(IOrderStatusService OrderStatusService, IMapper mapper, IImageUploader imageUploader, IStatusService statusService) : base(OrderStatusService, mapper, imageUploader)
        {
            _OrderStatusService = OrderStatusService;
            _statusService = statusService;
        }

        [Authorize(AppRole.Admin)]
        public async Task<ActionResult> CreateCustom(int orderId)
        {
            ViewData["Status"] = new SelectList(await _statusService.GetAllAsync(), "Id", "Name");
            ViewData["orderId"] = orderId;
            return PartialView();
        }
        [Authorize(AppRole.Admin)]
        public override Task<ActionResult> Create()
        {
            return base.Create();
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

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Edit(int id)
        {
            return base.Edit(id);
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Index(Dictionary<string, string>? filters, string? sortField, string? sortDirection, int page = 1, int size = 10)
        {
            return base.Index(filters, sortField, sortDirection, page, size);
        }
    }
}
