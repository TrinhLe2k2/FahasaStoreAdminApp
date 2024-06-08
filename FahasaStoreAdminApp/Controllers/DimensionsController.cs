using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class DimensionsController : GenericController<Dimension, DimensionModel, int>
    {
        private readonly IDimensionService _DimensionService;
        public DimensionsController(IDimensionService DimensionService, IMapper mapper, IImageUploader imageUploader) : base(DimensionService, mapper, imageUploader)
        {
            _DimensionService = DimensionService;
        }
    }
}
