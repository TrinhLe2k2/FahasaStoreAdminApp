using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class PartnerTypeData
    {
        public List<PartnerTypeForm> PartnerTypes { get; }

        public PartnerTypeData()
        {
            PartnerTypes = [];
            for (int i = 1; i < 13; i++)
            {
                PartnerTypeForm PartnerType = new(i, "PartnerType " + i);
                PartnerTypes.Add(PartnerType);
            }
        }

        public PartnerTypeForm? PartnerType(int id)
        {
            var PartnerType = PartnerTypes.SingleOrDefault(e => e.PartnerTypeId == id);
            return PartnerType;
        }

        public IEnumerable<PartnerTypeForm> ListPartnerTypes()
        {
            return PartnerTypes;
        }
    }
}
