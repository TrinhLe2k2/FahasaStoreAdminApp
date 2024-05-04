using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAPI.Models.FormModels
{
    public class UserForm
    {
        public int UserId { get; set; }
        [Display(Name = "Loại tài khoản")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public int? RoleId { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Trường này  không được để trống")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"^(\+?84|0)\d{9,10}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = null!;
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; } = null!;
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [Required(ErrorMessage = "Trường này không được để trống")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "Ảnh đại diện")]
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
