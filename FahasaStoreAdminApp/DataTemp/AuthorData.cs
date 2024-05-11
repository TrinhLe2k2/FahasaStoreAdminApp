using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class AuthorData
    {
        public List<AuthorForm> Authors { get; }

        public AuthorData()
        {
            Authors = [];
            for (int i = 1; i < 13; i++)
            {
                AuthorForm Author = new(i, "Author " + i);
                Authors.Add(Author);
            }
        }

        public AuthorForm? Author(int id)
        {
            var Author = Authors.SingleOrDefault(e => e.AuthorId == id);
            return Author;
        }

        public IEnumerable<AuthorForm> ListAuthors()
        {
            return Authors;
        }
    }
}
