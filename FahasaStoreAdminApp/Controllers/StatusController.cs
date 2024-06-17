﻿using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Filters;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services;
using FahasaStoreAdminApp.Services.EntityService;
using Microsoft.AspNetCore.Mvc;

namespace FahasaStoreAdminApp.Controllers
{
    public class StatusController : GenericController<Status, StatusModel, StatusDTO, int>
    {
        private readonly IStatusService _StatusService;
        public StatusController(IStatusService StatusService, IMapper mapper, IImageUploader imageUploader) : base(StatusService, mapper, imageUploader)
        {
            _StatusService = StatusService;
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

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override Task<IActionResult> Index(Dictionary<string, string>? filters, string? sortField, string? sortDirection, int page = 1, int size = 10)
        {
            return base.Index(filters, sortField, sortDirection, page, size);
        }
    }
}
