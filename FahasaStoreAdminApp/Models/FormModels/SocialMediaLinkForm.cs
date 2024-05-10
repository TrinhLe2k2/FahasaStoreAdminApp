using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.FormModels
{
    public class SocialMediaLinkForm
    {
        public SocialMediaLinkForm(int linkId, string platform, string imageUrl, string link)
        {
            LinkId = linkId;
            Platform = platform;
            ImageUrl = imageUrl;
            Link = link;
        }

        [Display(Name = "ID")]
        public int LinkId { get; set; }
        [Display(Name = "Platform")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Platform { get; set; } = null!;
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string ImageUrl { get; set; } = null!;
        [Display(Name = "Link")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Link { get; set; } = null!;
    }
}
