using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class CoverTypesController : GenericController<CoverType, CoverTypeModel, int>
    {
        private readonly ICoverTypeService _CoverTypeService;
        public CoverTypesController(ICoverTypeService CoverTypeService, IMapper mapper, IImageUploader imageUploader) : base(CoverTypeService, mapper, imageUploader)
        {
            _CoverTypeService = CoverTypeService;
        }
    }
}
