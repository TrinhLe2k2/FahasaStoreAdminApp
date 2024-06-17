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
    public class NotificationsController : GenericController<Notification, NotificationModel, NotificationDTO, int>
    {
        private readonly INotificationService _NotificationService;
        private readonly INotificationTypeService _notificationTypeService;
        private readonly IUserService _userService;
        public NotificationsController(INotificationService NotificationService, IMapper mapper, IImageUploader imageUploader, INotificationTypeService notificationTypeService, IUserService userService) : base(NotificationService, mapper, imageUploader)
        {
            _NotificationService = NotificationService;
            _notificationTypeService = notificationTypeService;
            _userService = userService;
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<ActionResult> Create()
        {
            ViewData["NotificationType"] = new SelectList(await _notificationTypeService.GetAllAsync(), "Id", "Name");
            ViewData["Users"] = new SelectList(await _userService.GetAllAsync(), "Id", "Email");
            return await base.Create();
        }

        [Authorize(AppRole.Admin, AppRole.Staff)]
        public override async Task<IActionResult> Edit(int id)
        {
            ViewData["NotificationType"] = new SelectList(await _notificationTypeService.GetAllAsync(), "Id", "Name");
            ViewData["Users"] = new SelectList(await _userService.GetAllAsync(), "Id", "Email");
            return await base.Edit(id);
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
        public override Task<IActionResult> Index(Dictionary<string, string>? filters, string? sortField, string? sortDirection, int page = 1, int size = 10)
        {
            return base.Index(filters, sortField, sortDirection, page, size);
        }
    }
}
