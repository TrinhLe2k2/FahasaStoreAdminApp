using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class BannerData
    {
        public List<BannerForm> Banners { get; }

        public BannerData()
        {
            Banners = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                BannerForm Banner = new(i, urlImage, "Banner "+i, "Content "+i, new DateTime());
                Banners.Add(Banner);
            }
        }

        public BannerForm? Banner(int id)
        {
            var Banner = Banners.SingleOrDefault(e => e.BannerId == id);
            return Banner;
        }

        public IEnumerable<BannerForm> ListBanners()
        {
            return Banners;
        }
    }
}
