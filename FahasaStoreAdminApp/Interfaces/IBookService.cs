using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;
using System.Collections.ObjectModel;

namespace FahasaStoreAdminApp.Interfaces
{
    public interface IBookService
    {
        Task<ICollection<BookEntities>> GetBooksAsync();
        Task<BookEntities> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookForm book);
        Task<int> UpdateBookAsync(int id, BookForm book);
        Task<bool> DeleteBookAsync(int id);
    }
}
