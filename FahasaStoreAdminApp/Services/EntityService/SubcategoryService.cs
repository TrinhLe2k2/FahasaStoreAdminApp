using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Models.EModels;
using Newtonsoft.Json;

namespace FahasaStoreAdminApp.Services.EntityService
{
    public interface ISubcategoryService : IGenericService<Subcategory, SubcategoryModel, int>
    {
    }
    public class SubcategoryService : GenericService<Subcategory, SubcategoryModel, int>, ISubcategoryService
    {
        public SubcategoryService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Subcategories") { }

    }
}
