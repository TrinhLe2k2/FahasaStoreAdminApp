namespace FahasaStoreAPI.Models.FormModels
{
    public class CoverTypeForm
    {
        public CoverTypeForm() { }
        public CoverTypeForm(int coverTypeId, string typeName)
        {
            CoverTypeId = coverTypeId;
            TypeName = typeName;
        }

        public int CoverTypeId { get; set; }
        public string TypeName { get; set; } = null!;
    }
}
