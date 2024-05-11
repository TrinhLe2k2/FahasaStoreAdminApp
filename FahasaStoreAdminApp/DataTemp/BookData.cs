using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class BookData
    {
        public List<BookForm> Books { get; }

        public BookData()
        {
            Books = [];
            for (int i = 1; i < 13; i++)
            {
                BookForm Book = new(i, i, i, i, i, i, "Book "+i, "des "+i, 2000+i, 2000, 20, 999, 200, 200);
                Books.Add(Book);
            }
        }

        public BookForm? Book(int id)
        {
            var Book = Books.SingleOrDefault(e => e.BookId == id);
            return Book;
        }

        public IEnumerable<BookForm> ListBooks()
        {
            return Books;
        }
    }
}
