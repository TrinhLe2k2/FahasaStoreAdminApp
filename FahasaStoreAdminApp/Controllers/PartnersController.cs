using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using FahasaStoreAdminApp.Models.DTO;
using Microsoft.AspNetCore.Components.QuickGrid;
using static NuGet.Packaging.PackagingConstants;
using FahasaStoreAdminApp.Filters;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnersController : GenericController<Partner, PartnerModel, PartnerDTO, int>
    {
        private readonly IPartnerTypeService _partnerTypeService;
        private readonly IPartnerService _PartnerService;
        public PartnersController(IPartnerTypeService partnerTypeService, IPartnerService PartnerService, IMapper mapper, IImageUploader imageUploader) : base(PartnerService, mapper, imageUploader)
        {
            _partnerTypeService = partnerTypeService;
            _PartnerService = PartnerService;
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<IActionResult> Index(
            Dictionary<string, string>? filters,
            string? sortField,
            string? sortDirection,
            int page = 1,
            int size = 10)
        {
            ViewData["PartnerTypes"] = await _partnerTypeService.GetAllAsync();
            return await base.Index(filters, sortField, sortDirection, page, size);
        }

        [Authorize(AppRole.Admin)]
        public override async Task<ActionResult> Create()
        {
            ViewData["PartnerTypes"] = new SelectList(await _partnerTypeService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

        [Authorize(AppRole.Admin)]
        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["PartnerTypes"] = new SelectList(await _partnerTypeService.GetAllAsync(), "Id", "Name");
            return await base.Edit(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public async Task<ActionResult> GetPartnersByPartnerType(string id)
        {
            return PartialView(await _PartnerService.GetListByAsync("PartnerTypeId", id));
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
