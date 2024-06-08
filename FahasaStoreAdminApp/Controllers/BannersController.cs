using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class BannersController : GenericController<Banner, BannerModel, int>
    {
        private readonly IBannerService _BannerService;
        public BannersController(IBannerService BannerService, IMapper mapper, IImageUploader imageUploader) : base(BannerService, mapper, imageUploader)
        {
            _BannerService = BannerService;
        }
    }
}
