using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class CoverTypeData
    {
        public List<CoverTypeForm> CoverTypes { get; }

        public CoverTypeData()
        {
            CoverTypes = [];
            for (int i = 1; i < 13; i++)
            {
                CoverTypeForm CoverType = new(i, "CoverType " + i);
                CoverTypes.Add(CoverType);
            }
        }

        public CoverTypeForm? CoverType(int id)
        {
            var CoverType = CoverTypes.SingleOrDefault(e => e.CoverTypeId == id);
            return CoverType;
        }

        public IEnumerable<CoverTypeForm> ListCoverTypes()
        {
            return CoverTypes;
        }
    }
}
