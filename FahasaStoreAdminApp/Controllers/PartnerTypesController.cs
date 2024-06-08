using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class PartnerTypesController : GenericController<PartnerType, PartnerTypeModel, int>
    {
        private readonly IPartnerTypeService _PartnerTypeService;
        public PartnerTypesController(IPartnerTypeService PartnerTypeService, IMapper mapper, IImageUploader imageUploader) : base(PartnerTypeService, mapper, imageUploader)
        {
            _PartnerTypeService = PartnerTypeService;
        }
    }
}
