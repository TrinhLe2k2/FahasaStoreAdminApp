using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.FormModels
{
    public class SocialMediaLinkForm
    {
        public int LinkId { get; set; }
        [Display(Name = "Platform")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Platform { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Link { get; set; } = null!;
    }
}
