using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class PartnerData
    {
        public List<PartnerForm> Partners { get; }

        public PartnerData()
        {
            Partners = [];
            for (int i = 1; i < 13; i++)
            {
                string urlImage = "/image/MenuImage/lf" + i + ".png";
                PartnerForm Partner = new(i, i, "Partner " + i, "Address " + i, "Phone "+i, "Email "+i, urlImage);
                Partners.Add(Partner);
            }
        }

        public PartnerForm? Partner(int id)
        {
            var Partner = Partners.SingleOrDefault(e => e.PartnerId == id);
            return Partner;
        }

        public IEnumerable<PartnerForm> ListPartners()
        {
            return Partners;
        }
    }
}
