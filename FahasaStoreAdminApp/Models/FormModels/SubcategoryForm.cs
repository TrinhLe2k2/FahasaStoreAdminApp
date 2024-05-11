namespace FahasaStoreAPI.Models.FormModels
{
    public class SubcategoryForm
    {
        public SubcategoryForm(int subcategoryId, int? categoryId, string name, string imageUrl)
        {
            SubcategoryId = subcategoryId;
            CategoryId = categoryId;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int SubcategoryId { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
