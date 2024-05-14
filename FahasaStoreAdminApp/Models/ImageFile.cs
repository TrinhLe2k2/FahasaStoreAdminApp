using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAdminApp.Models
{
    public class ImageFile
    {
        public ImageFile(string? image)
        {
            Image = image;
        }
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        public string Image { get; set; }
    }
}
