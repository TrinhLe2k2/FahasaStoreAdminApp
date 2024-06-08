using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class MenusController : GenericController<Menu, MenuModel, int>
    {
        private readonly IMenuService _MenuService;
        public MenusController(IMenuService menuService, IMapper mapper, IImageUploader imageUploader) : base(menuService, mapper, imageUploader)
        {
            _MenuService = menuService;
        }
    }
}
