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

namespace FahasaStoreAdminApp.Controllers
{
    public class UsersController : GenericController<AspNetUser, AspNetUserModel, AspNetUserDTO, string>
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        public UsersController(IUserService userService, IMapper mapper, IImageUploader imageUploader, IAccountService accountService) : base(userService, mapper, imageUploader)
        {
            _userService = userService;
            _accountService = accountService;
        }
        [Authorize(AppRole.Admin)]
        public IActionResult RemoveRoleFromUser(string userId, string role, string? email)
        {
            ViewData["userId"] = userId;
            ViewData["role"] = role;
            ViewData["email"] = email;
            return PartialView();
        }

        [Authorize(AppRole.Admin)]
        public IActionResult AddRoleToUser(string userId, string? email)
        {
            ViewData["userId"] = userId;
            ViewData["email"] = email;
            ViewData["roles"] = AppRole.Roles.ToList();

            return PartialView();
        }
        [Authorize(AppRole.Admin)]
        public override Task<ActionResult> Create()
        {
            return base.Create();
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Delete(string id)
        {
            return base.Delete(id);
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Details(string id)
        {
            return base.Details(id);
        }

        [Authorize(AppRole.Admin)]
        public override Task<IActionResult> Edit(string id)
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
