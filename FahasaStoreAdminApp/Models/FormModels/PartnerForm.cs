namespace FahasaStoreAPI.Models.FormModels
{
    public class PartnerForm
    {
        public PartnerForm() { }
        public PartnerForm(int partnerId, int partnerTypeId, string name, string address, string phone, string email, string imageUrl)
        {
            PartnerId = partnerId;
            PartnerTypeId = partnerTypeId;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            ImageUrl = imageUrl;
        }

        public int PartnerId { get; set; }
        public int PartnerTypeId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
    }
}
