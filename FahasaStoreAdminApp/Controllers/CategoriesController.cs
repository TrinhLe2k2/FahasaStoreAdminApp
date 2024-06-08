using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class CategoriesController : GenericController<Category, CategoryModel, int>
    {
        private readonly ICategoryService _CategoryService;
        public CategoriesController(ICategoryService CategoryService, IMapper mapper, IImageUploader imageUploader) : base(CategoryService, mapper, imageUploader)
        {
            _CategoryService = CategoryService;
        }
    }
}
