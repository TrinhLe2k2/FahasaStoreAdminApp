namespace FahasaStoreAPI.Models.FormModels
{
    public class AuthorForm
    {
        public AuthorForm() { }
        public AuthorForm(int authorId, string name)
        {
            AuthorId = authorId;
            Name = name;
        }

        public int AuthorId { get; set; }
        public string Name { get; set; } = null!;
    }
}
