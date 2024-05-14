using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface IAuthorService
    {
        Task<ICollection<AuthorEntities>> GetAuthorsAsync();
        Task<AuthorEntities> GetAuthorByIdAsync(int id);
        Task<int> AddAuthorAsync(AuthorForm Author);
        Task<int> UpdateAuthorAsync(int id, AuthorForm Author);
        Task<bool> DeleteAuthorAsync(int id);
    }
}
