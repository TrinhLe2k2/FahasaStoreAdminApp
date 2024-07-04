using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAdminApp.Models.EModels
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        [DisplayName("Người Nhận")]
        public string ReceiverName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public bool DefaultAddress { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class AspNetRoleModel
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }

    public class AspNetUserModel
    {
        public string Id { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }

    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class BannerModel
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class BookModel
    {
        public int Id { get; set; }
        [Display(Name = "Thể Loại")]
        public int SubcategoryId { get; set; }
        [Display(Name = "Tác Giả")]
        public int AuthorId { get; set; }
        [Display(Name = "Loại Bìa")]
        public int CoverTypeId { get; set; }
        [Display(Name = "Kích Thước")]
        public int DimensionId { get; set; }
        [Display(Name = "Tên Sách")]
        public string Name { get; set; } = null!;
        [Display(Name = "Mô Tả")]
        public string Description { get; set; } = null!;
        [Display(Name = "Giá Gốc")]
        public int Price { get; set; }
        [Display(Name = "Giảm Giá %")]
        public int DiscountPercentage { get; set; }
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Khối Lượng (g)")]
        public double? Weight { get; set; }
        [Display(Name = "Số Trang")]
        public int? PageCount { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class BookPartnerModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PartnerId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CartItemModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CartModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class CoverTypeModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class DimensionModel
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Unit { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class FavouriteModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int BookId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FlashSaleBookModel
    {
        public int Id { get; set; }
        public int FlashSaleId { get; set; }
        public int BookId { get; set; }
        public int DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class FlashSaleModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class MenuModel
    {
        public int Id { get; set; }
        [Required()]
        public string Name { get; set; } = null!;
        public string Link { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class NotificationModel
    {
        public int Id { get; set; }
        public int NotificationTypeId { get; set; }
        public string? UserId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class NotificationTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderItemModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderModel
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int? VoucherId { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        public int AddressId { get; set; }
        public int PaymentMethodId { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class OrderStatusModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Trạng Thái")]
        public int StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PartnerModel
    {
        public int Id { get; set; }
        public int PartnerTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PartnerTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class PaymentMethodModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PaymentModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class PlatformModel
    {
        public int Id { get; set; }
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class PosterImageModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool ImageDefault { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class ReviewModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; } = null!;
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class SubcategoryModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class TopicContentModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class TopicModel
    {
        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }

    public class VoucherModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinOrderAmount { get; set; }
        public int MaxDiscountAmount { get; set; }
        public int UsageLimit { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

    public class WebsiteModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LogoUrl { get; set; } = null!;
        public string IconUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
