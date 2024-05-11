using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class SubcategoryData
    {
        public List<SubcategoryForm> Subcategorys { get; }

        public SubcategoryData()
        {
            Subcategorys = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                SubcategoryForm Subcategory = new(i, i, "Subcategory " + i, urlImage);
                Subcategorys.Add(Subcategory);
            }
        }

        public SubcategoryForm? Subcategory(int id)
        {
            var Subcategory = Subcategorys.SingleOrDefault(e => e.SubcategoryId == id);
            return Subcategory;
        }

        public IEnumerable<SubcategoryForm> ListSubcategorys()
        {
            return Subcategorys;
        }
    }
}
