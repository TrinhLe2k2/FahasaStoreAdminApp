using FahasaStoreAPI.Entities;

namespace FahasaStoreAdminApp.Models.ViewModel
{
    public class PaginatedBooksVM
    {
        public PaginatedBooksVM()
        {
            books = new List<Book>();
        }

        public List<Book> books { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        // Optional: Information for pagination display
        public int StartPage { get; set; }
        public int EndPage { get; set; }
    }

}
