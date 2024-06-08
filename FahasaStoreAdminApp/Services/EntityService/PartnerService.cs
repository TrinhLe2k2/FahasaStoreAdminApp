using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Models.EModels;
using Newtonsoft.Json;

namespace FahasaStoreAdminApp.Services.EntityService
{
    public interface IPartnerService : IGenericService<Partner, PartnerModel, int> 
    {
    }
    public class PartnerService : GenericService<Partner, PartnerModel, int>, IPartnerService
    {
        public PartnerService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Partners") { }

    }
}
