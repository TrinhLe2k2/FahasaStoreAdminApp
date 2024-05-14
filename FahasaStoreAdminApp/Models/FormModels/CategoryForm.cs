namespace FahasaStoreAPI.Models.FormModels
{
    public class CategoryForm
    {
        public CategoryForm() { }
        public CategoryForm(int categoryId, string name, string imageUrl)
        {
            CategoryId = categoryId;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
