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
    public class PartnersController : GenericController<Partner, PartnerModel, int>
    {
        private readonly IPartnerTypeService _partnerTypeService;
        private readonly IPartnerService _PartnerService;
        public PartnersController(IPartnerTypeService partnerTypeService, IPartnerService PartnerService, IMapper mapper, IImageUploader imageUploader) : base(PartnerService, mapper, imageUploader)
        {
            _partnerTypeService = partnerTypeService;
            _PartnerService = PartnerService;
        }

        public override async Task<IActionResult> Index()
        {
            ViewData["PartnerTypes"] = await _partnerTypeService.GetAllAsync();
            return await base.Index();
        }

        public override async Task<ActionResult> Create()
        {
            ViewData["PartnerTypes"] = new SelectList(await _partnerTypeService.GetAllAsync(), "Id", "Name");
            return PartialView();
        }

        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["PartnerTypes"] = new SelectList(await _partnerTypeService.GetAllAsync(), "Id", "Name");
            return await base.Edit(id);
        }

        public async Task<ActionResult> GetPartnersByPartnerType(string id)
        {
            return PartialView(await _PartnerService.GetListByAsync("PartnerTypeId", id));
        }
    }
}
