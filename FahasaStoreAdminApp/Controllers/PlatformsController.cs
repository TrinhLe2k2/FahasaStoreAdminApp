using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class PlatformsController : GenericController<Platform, PlatformModel, int>
    {
        private readonly IPlatformService _PlatformService;
        public PlatformsController(IPlatformService PlatformService, IMapper mapper, IImageUploader imageUploader) : base(PlatformService, mapper, imageUploader)
        {
            _PlatformService = PlatformService;
        }
    }
}
