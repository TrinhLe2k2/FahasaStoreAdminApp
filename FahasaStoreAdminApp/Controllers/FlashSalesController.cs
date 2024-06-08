using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class FlashSalesController : GenericController<FlashSale, FlashSaleModel, int>
    {
        private readonly IFlashSaleService _FlashSaleService;
        public FlashSalesController(IFlashSaleService FlashSaleService, IMapper mapper, IImageUploader imageUploader) : base(FlashSaleService, mapper, imageUploader)
        {
            _FlashSaleService = FlashSaleService;
        }
    }
}
