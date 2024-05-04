using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.FormModels
{
    public class WebsiteForm
    {
        public WebsiteForm(string name, string logoUrl, string iconUrl, string description, string address, string phone, string email)
        {
            Name = name;
            LogoUrl = logoUrl;
            IconUrl = iconUrl;
            Description = description;
            Address = address;
            Phone = phone;
            Email = email;
        }

        //public int WebsiteId { get; set; }
        [Display(Name= "Tên cửa hàng")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Name { get; set; } = null!;
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string LogoUrl { get; set; }
        [Display(Name = "Icon")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string IconUrl { get; set; }
        [Display(Name = "Giới thiệu")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Description { get; set; } = null!;
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string Address { get; set; } = null!;
        [Display(Name = "Hot line")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        [RegularExpression(@"^(\+?84|0)\d{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = null!;
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;
    }
}
