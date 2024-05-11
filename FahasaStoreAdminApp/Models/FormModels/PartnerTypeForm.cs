namespace FahasaStoreAPI.Models.FormModels
{
    public class PartnerTypeForm
    {
        public PartnerTypeForm(int partnerTypeId, string name)
        {
            PartnerTypeId = partnerTypeId;
            Name = name;
        }

        public int PartnerTypeId { get; set; }
        public string Name { get; set; } = null!;
    }
}
