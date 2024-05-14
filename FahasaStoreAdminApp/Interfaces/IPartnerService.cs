using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface IPartnerService
    {
        Task<ICollection<PartnerEntities>> GetPartnersAsync();
        Task<ICollection<PartnerEntities>> GetPartnersByType(int id);
        Task<PartnerEntities> GetPartnerByIdAsync(int id);
        Task<int> AddPartnerAsync(PartnerForm Partner);
        Task<int> UpdatePartnerAsync(int id, PartnerForm Partner);
        Task<bool> DeletePartnerAsync(int id);
    }
}
