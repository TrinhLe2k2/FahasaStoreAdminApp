using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class DimensionsController : GenericController<Dimension, DimensionModel, DimensionDTO, int>
    {
        private readonly IDimensionService _DimensionService;
        public DimensionsController(IDimensionService DimensionService, IMapper mapper, IImageUploader imageUploader) : base(DimensionService, mapper, imageUploader)
        {
            _DimensionService = DimensionService;
        }
        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<ActionResult> Create()
        {
            return base.Create();
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Details(int id)
        {
            return base.Details(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Edit(int id)
        {
            return base.Edit(id);
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Index(Dictionary<string, string>? filters, string? sortField, string? sortDirection, int page = 1, int size = 10)
        {
            return base.Index(filters, sortField, sortDirection, page, size);
        }
    }
}
