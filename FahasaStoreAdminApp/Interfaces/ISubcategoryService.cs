using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface ISubcategoryService
    {
        Task<ICollection<SubcategoryEntities>> GetSubcategoriesAsync();
        Task<ICollection<SubcategoryEntities>> GetSubcategoriesByCategoryID(int id);
        Task<SubcategoryEntities> GetSubcategoryByIdAsync(int id);
        Task<int> AddSubcategoryAsync(SubcategoryForm Subcategory);
        Task<int> UpdateSubcategoryAsync(int id, SubcategoryForm Subcategory);
        Task<bool> DeleteSubcategoryAsync(int id);
    }
}
