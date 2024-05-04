using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.FormModels
{
    public class MenuForm
    {
        public MenuForm()
        {
            
        }
        public MenuForm(int menuId, string name, string link, string imageUrl)
        {
            MenuId = menuId;
            Name = name;
            Link = link;
            ImageUrl = imageUrl;
        }
        [Display(Name = "Id")]
        public int MenuId { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; } = null!;
        [Display(Name = "Link")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Link { get; set; } = null!;
        [Display(Name = "Hình Ảnh")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string ImageUrl { get; set; } = null!;
    }
}
