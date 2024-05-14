namespace FahasaStoreAPI.Models.FormModels
{
    public class DimensionForm
    {
        public DimensionForm() { }
        public DimensionForm(int dimensionId, double length, double width, double height, string unit)
        {
            DimensionId = dimensionId;
            Length = length;
            Width = width;
            Height = height;
            Unit = unit;
        }

        public int DimensionId { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Unit { get; set; } = null!;
    }
}
