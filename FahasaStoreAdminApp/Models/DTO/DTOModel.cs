using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Models.EModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FahasaStoreAdminApp.Models.DTO
{
    public partial class AddressDTO
    {
        public AddressDTO()
        {
            Orders = new HashSet<OrderModel>();
        }

        public int Id { get; set; }
        public string ReceiverName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Ward { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public bool DefaultAddress { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual AspNetUserModel User { get; set; } = null!;
        public virtual ICollection<OrderModel> Orders { get; set; }
    }
    public partial class AspNetRoleDTO
    {
        public AspNetRoleDTO()
        {
            Users = new HashSet<AspNetUserModel>();
        }

        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetUserModel> Users { get; set; }
    }
    public partial class AspNetUserDTO
    {
        public AspNetUserDTO()
        {
            Addresses = new HashSet<AddressModel>();
            Favourites = new HashSet<FavouriteModel>();
            Notifications = new HashSet<NotificationModel>();
            Orders = new HashSet<OrderModel>();
            Reviews = new HashSet<ReviewModel>();
            Roles = new HashSet<AspNetRoleModel>();
        }
        [DisplayName("Mã Người Dùng")]
        public string Id { get; set; } = null!;
        [DisplayName("Họ Và Tên")]
        public string FullName { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Ảnh Đại Diện")]
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        [DisplayName("Địa Chỉ Email")]
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual CartModel? Cart { get; set; }
        public virtual ICollection<AddressModel> Addresses { get; set; }
        public virtual ICollection<FavouriteModel> Favourites { get; set; }
        public virtual ICollection<NotificationModel> Notifications { get; set; }
        public virtual ICollection<OrderModel> Orders { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
        [DisplayName("Vai Trò")]
        public virtual ICollection<AspNetRoleModel> Roles { get; set; }
    }
    public partial class AuthorDTO
    {
        public AuthorDTO()
        {
            Books = new HashSet<BookModel>();
        }
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Tên Tác Giả")]
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
    public partial class BannerDTO
    {
        [DisplayName("#")]
        public int Id { get; set; }
        public string? PublicId { get; set; }
        [DisplayName("Hình Ảnh")]
        public string? ImageUrl { get; set; }
        [DisplayName("Tiêu Đề")]
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        [DisplayName("Thời Gian")]
        public DateTime? CreatedAt { get; set; }
    }
    public partial class BookDTO
    {
        public BookDTO()
        {
            BookPartners = new HashSet<BookPartnerDTO>();
            CartItems = new HashSet<CartItemModel>();
            Favourites = new HashSet<FavouriteModel>();
            FlashSaleBooks = new HashSet<FlashSaleBookModel>();
            OrderItems = new HashSet<OrderItemModel>();
            PosterImages = new HashSet<PosterImageModel>();
            Reviews = new HashSet<ReviewModel>();
        }
        [DisplayName("Mã Sách")]
        public int Id { get; set; }
        [DisplayName("Tên Sách")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [DisplayName("Giá Gốc (đ)")]
        public int Price { get; set; }
        [DisplayName("Giảm Giá %")]
        public int DiscountPercentage { get; set; }
        [DisplayName("Số Lượng")]
        public int Quantity { get; set; }
        [DisplayName("Khối lượng (g)")]
        public double? Weight { get; set; }
        [DisplayName("Số Trang")]
        public int? PageCount { get; set; }
        public DateTime? CreatedAt { get; set; }
	    public int? QuantitySold { get; set; }

        [DisplayName("Tác Giả")]
        public virtual AuthorModel Author { get; set; } = null!;
        [DisplayName("Loại Bìa")]
        public virtual CoverTypeModel CoverType { get; set; } = null!;
        [DisplayName("Kích Thước")]
        public virtual DimensionModel Dimension { get; set; } = null!;
        [DisplayName("Thể Loại")]
        public virtual SubcategoryModel Subcategory { get; set; } = null!;
        [DisplayName("Đối Tác")]
        public virtual ICollection<BookPartnerDTO> BookPartners { get; set; }
        public virtual ICollection<CartItemModel> CartItems { get; set; }
        public virtual ICollection<FavouriteModel> Favourites { get; set; }
        public virtual ICollection<FlashSaleBookModel> FlashSaleBooks { get; set; }
        public virtual ICollection<OrderItemModel> OrderItems { get; set; }
        [DisplayName("Hình Ảnh")]
        public virtual ICollection<PosterImageModel> PosterImages { get; set; }
        public virtual ICollection<ReviewModel> Reviews { get; set; }
    }
    public partial class BookPartnerDTO
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookModel Book { get; set; } = null!;
        public virtual PartnerDTO Partner { get; set; } = null!;
    }
    public partial class CartDTO
    {
        public CartDTO()
        {
            CartItems = new HashSet<CartItemModel>();
        }

        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual AspNetUserModel User { get; set; } = null!;
        public virtual ICollection<CartItemModel> CartItems { get; set; }
    }
    public partial class CartItemDTO
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDTO Book { get; set; } = null!;
        public virtual CartModel Cart { get; set; } = null!;
    }
    public partial class CategoryDTO
    {
        public CategoryDTO()
        {
            Subcategories = new HashSet<SubcategoryModel>();
        }
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Tên Thể Loại")]
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Icon")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<SubcategoryModel> Subcategories { get; set; }
    }
    public partial class CoverTypeDTO
    {
        public CoverTypeDTO()
        {
            Books = new HashSet<BookModel>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Loại Bìa")]
        public string TypeName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
    public partial class DimensionDTO
    {
        public DimensionDTO()
        {
            Books = new HashSet<BookModel>();
        }
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Chiều Dài")]
        public int Length { get; set; }
        [DisplayName("Chiều Rộng")]
        public int Width { get; set; }
        [DisplayName("Chiều Cao")]
        public int Height { get; set; }
        [DisplayName("Đơn Vị")]
        public string Unit { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<BookModel> Books { get; set; }
    }
    public partial class FavouriteDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookModel Book { get; set; } = null!;
        public virtual AspNetUserModel User { get; set; } = null!;
    }
    public partial class FlashSaleDTO
    {
        public FlashSaleDTO()
        {
            FlashSaleBooks = new HashSet<FlashSaleBookModel>();
        }
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Thời Gian Bắt Đầu")]
        public DateTime StartDate { get; set; }
        [DisplayName("Thời Gian Kết Thúc")]
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<FlashSaleBookModel> FlashSaleBooks { get; set; }
    }
    public partial class FlashSaleBookDTO
    {
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("% Giảm")]
        public int DiscountPercentage { get; set; }
        [DisplayName("Số Lượng Bán")]
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public string? Poster { get; set; }
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Sách")]
        public virtual BookModel Book { get; set; } = null!;
        public virtual FlashSaleModel FlashSale { get; set; } = null!;
    }
    public partial class MenuDTO
    {
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Tên Menu")]
        public string Name { get; set; } = null!;
        [DisplayName("Liên Kết")]
        public string Link { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Hình Ảnh")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public partial class NotificationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsRead { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual NotificationTypeModel NotificationType { get; set; } = null!;
        public virtual AspNetUserModel? User { get; set; }
    }
    public partial class NotificationTypeDTO
    {
        public NotificationTypeDTO()
        {
            Notifications = new HashSet<NotificationModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<NotificationModel> Notifications { get; set; }
    }
    public partial class OrderDTO
    {
        public OrderDTO()
        {
            OrderItems = new HashSet<OrderItemDTO>();
            OrderStatuses = new HashSet<OrderStatusDTO>();
            Reviews = new HashSet<ReviewDTO>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        public string? Note { get; set; }
        [DisplayName("Thời Gian Đặt Hàng")]
        public DateTime? CreatedAt { get; set; }

        public virtual AddressModel Address { get; set; } = null!;
        public virtual PaymentMethodModel PaymentMethod { get; set; } = null!;
        public virtual AspNetUserModel User { get; set; } = null!;
        public virtual VoucherModel? Voucher { get; set; }
        public virtual PaymentModel? Payment { get; set; }
        public virtual ICollection<OrderItemDTO> OrderItems { get; set; }
        [DisplayName("Trạng Thái Đơn Hàng")]
        public virtual ICollection<OrderStatusDTO> OrderStatuses { get; set; }
        public virtual ICollection<ReviewDTO> Reviews { get; set; }
    }
    public partial class OrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookDTO Book { get; set; } = null!;
        public virtual OrderModel Order { get; set; } = null!;
    }
    public partial class OrderStatusDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual OrderModel Order { get; set; } = null!;
        public virtual StatusModel Status { get; set; } = null!;
    }
    public partial class PartnerDTO
    {
        public PartnerDTO()
        {
            BookPartners = new HashSet<BookPartnerModel>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Đối Tác")]
        public string Name { get; set; } = null!;
        [DisplayName("Địa Chỉ")]
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Logo")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Kiểu Đối Tác")]
        public virtual PartnerTypeModel PartnerType { get; set; } = null!;
        public virtual ICollection<BookPartnerModel> BookPartners { get; set; }
    }
    public partial class PartnerTypeDTO
    {
        public PartnerTypeDTO()
        {
            Partners = new HashSet<PartnerModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<PartnerModel> Partners { get; set; }
    }
    public partial class PaymentDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual OrderModel Order { get; set; } = null!;
    }
    public partial class PaymentMethodDTO
    {
        public PaymentMethodDTO()
        {
            Orders = new HashSet<OrderModel>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Phương Thức Thanh Toán")]
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
    }
    public partial class PlatformDTO
    {
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Nền Tảng")]
        public string PlatformName { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Logo")]
        public string? ImageUrl { get; set; }
        [DisplayName("Liên Kết")]
        public string Link { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
    public partial class PosterImageDTO
    {
        public int Id { get; set; }
        public string? PublicId { get; set; }
        public string? ImageUrl { get; set; }
        public bool ImageDefault { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookModel Book { get; set; } = null!;
    }
    public partial class ReviewDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; } = null!;
        public int OrderId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual BookModel Book { get; set; } = null!;
        public virtual OrderModel Order { get; set; } = null!;
        public virtual AspNetUserModel User { get; set; } = null!;
    }
    public partial class StatusDTO
    {
        public StatusDTO()
        {
            OrderStatuses = new HashSet<OrderStatusModel>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Trạng Thái")]
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<OrderStatusModel> OrderStatuses { get; set; }
    }
    public partial class SubcategoryDTO
    {
        public SubcategoryDTO()
        {
            Books = new HashSet<BookModel>();
        }

        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Thể Loại con")]
        public string Name { get; set; } = null!;
        public string? PublicId { get; set; }
        [DisplayName("Icon")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Thể Loại")]
        public virtual CategoryModel Category { get; set; } = null!;
        public virtual ICollection<BookModel> Books { get; set; }
    }
    public partial class TopicDTO
    {
        public TopicDTO()
        {
            TopicContents = new HashSet<TopicContentModel>();
        }

        public int Id { get; set; }
        public string TopicName { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<TopicContentModel> TopicContents { get; set; }
    }
    public partial class TopicContentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }

        public virtual TopicModel Topic { get; set; } = null!;
    }
    public partial class VoucherDTO
    {
        public VoucherDTO()
        {
            Orders = new HashSet<OrderModel>();
        }
        [DisplayName("#")]
        public int Id { get; set; }
        [DisplayName("Tiêu Đề")]
        public string Name { get; set; } = null!;
        [DisplayName("Mã")]
        public string Code { get; set; } = null!;
        [DisplayName("Mô Tả")]
        public string? Description { get; set; }
        [DisplayName("% Giảm Giá")]
        public int DiscountPercent { get; set; }
        [DisplayName("Thời Gian bắt đầu")]
        public DateTime StartDate { get; set; }
        [DisplayName("Thời Gian Hết Hạn")]
        public DateTime EndDate { get; set; }
        [DisplayName("Đơn Hàng Tối Thiểu")]
        public int MinOrderAmount { get; set; }
        [DisplayName("Giảm Tối Đa")]
        public int MaxDiscountAmount { get; set; }
        [DisplayName("Số Lượng")]
        public int UsageLimit { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<OrderModel> Orders { get; set; }
    }
    public partial class WebsiteDTO
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
