using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface IDimensionService
    {
        Task<ICollection<DimensionEntities>> GetDimensionsAsync();
        Task<DimensionEntities> GetDimensionByIdAsync(int id);
        Task<int> AddDimensionAsync(DimensionForm Dimension);
        Task<int> UpdateDimensionAsync(int id, DimensionForm Dimension);
        Task<bool> DeleteDimensionAsync(int id);
    }
}
