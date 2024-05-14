using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface ICoverTypeService
    {
        Task<ICollection<CoverTypeEntities>> GetCoverTypesAsync();
        Task<CoverTypeEntities> GetCoverTypeByIdAsync(int id);
        Task<int> AddCoverTypeAsync(CoverTypeForm CoverType);
        Task<int> UpdateCoverTypeAsync(int id, CoverTypeForm CoverType);
        Task<bool> DeleteCoverTypeAsync(int id);
    }
}
