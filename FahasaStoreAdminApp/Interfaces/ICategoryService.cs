using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryEntities>> GetCategorysAsync();
        Task<CategoryEntities> GetCategoryByIdAsync(int id);
        Task<int> AddCategoryAsync(CategoryForm Category);
        Task<int> UpdateCategoryAsync(int id, CategoryForm Category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
