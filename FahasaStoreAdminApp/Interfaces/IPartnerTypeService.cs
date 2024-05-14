using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface IPartnerTypeService
    {
        Task<ICollection<PartnerTypeEntities>> GetPartnerTypesAsync();
        Task<PartnerTypeEntities> GetPartnerTypeByIdAsync(int id);
        Task<int> AddPartnerTypeAsync(PartnerTypeForm PartnerType);
        Task<int> UpdatePartnerTypeAsync(int id, PartnerTypeForm PartnerType);
        Task<bool> DeletePartnerTypeAsync(int id);
    }
}
