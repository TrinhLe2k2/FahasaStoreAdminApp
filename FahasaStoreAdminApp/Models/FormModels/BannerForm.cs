namespace FahasaStoreAPI.Models.FormModels
{
    public class BannerForm
    {
        public BannerForm(int bannerId, string imageUrl, string title, string content, DateTime createdAt)
        {
            BannerId = bannerId;
            ImageUrl = imageUrl;
            Title = title;
            Content = content;
            CreatedAt = createdAt;
        }

        public int BannerId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
