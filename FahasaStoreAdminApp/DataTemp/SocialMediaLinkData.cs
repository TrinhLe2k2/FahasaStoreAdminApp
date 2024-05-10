using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class SocialMediaLinkData
    {
        public List<SocialMediaLinkForm> SocialMediaLinks { get; }

        public SocialMediaLinkData()
        {
            SocialMediaLinks = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                SocialMediaLinkForm SocialMediaLink = new(i, "Facebook", urlImage, "fb.com");
                SocialMediaLinks.Add(SocialMediaLink);
            }
        }

        public SocialMediaLinkForm? SocialMediaLink(int id)
        {
            var SocialMediaLink = SocialMediaLinks.SingleOrDefault(e => e.LinkId == id);
            return SocialMediaLink;
        }

        public IEnumerable<SocialMediaLinkForm> ListSocialMediaLinks()
        {
            return SocialMediaLinks;
        }
    }
}
