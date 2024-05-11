using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp.DataTemp
{
    public class DimensionData
    {
        public List<DimensionForm> Dimensions { get; }

        public DimensionData()
        {
            Dimensions = [];
            for (int i = 1; i < 13; i++)
            {
                DimensionForm Dimension = new(i, i*2, i, i/2, "cm");
                Dimensions.Add(Dimension);
            }
        }

        public DimensionForm? Dimension(int id)
        {
            var Dimension = Dimensions.SingleOrDefault(e => e.DimensionId == id);
            return Dimension;
        }

        public IEnumerable<DimensionForm> ListDimensions()
        {
            return Dimensions;
        }
    }
}
