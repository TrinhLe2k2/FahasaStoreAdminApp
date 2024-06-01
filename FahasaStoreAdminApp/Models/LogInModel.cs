using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAdminApp.Models
{
    public class LogInModel
    {
        public LogInModel()
        {
            Email = "";
            Password = "";
        }
        public LogInModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [Required(ErrorMessage = "Vui lòng nhập email"), EmailAddress(ErrorMessage = "Vui lòng nhập email hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
