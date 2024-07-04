using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAdminApp.Entities
{
    public partial class Website
    {
        public int Id { get; set; }
        [Display(Name = "Tên Website")]
        public string Name { get; set; } = null!;
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; } = null!;
        [Display(Name = "Icon")]
        public string IconUrl { get; set; } = null!;
        [Display(Name = "Giới Thiệu")]
        public string Description { get; set; } = null!;
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; } = null!;
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; } = null!;
        [Display(Name = "Địa Chỉ Email")]
        public string Email { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
