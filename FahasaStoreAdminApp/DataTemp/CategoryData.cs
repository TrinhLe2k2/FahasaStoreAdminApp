using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class CategoryData
    {
        public List<CategoryForm> Categorys { get; }

        public CategoryData()
        {
            Categorys = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                CategoryForm Category = new(i, "Category " + i, urlImage);
                Categorys.Add(Category);
            }
        }

        public CategoryForm? Category(int id)
        {
            var Category = Categorys.SingleOrDefault(e => e.CategoryId == id);
            return Category;
        }

        public IEnumerable<CategoryForm> ListCategorys()
        {
            return Categorys;
        }
    }
}
