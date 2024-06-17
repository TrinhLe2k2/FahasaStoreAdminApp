using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.EModels;

namespace FahasaStoreAdminApp.Services.EntityService
{
    public interface IAddressService : IGenericService<Address, AddressModel, AddressDTO, int> { }
    public class AddressService : GenericService<Address, AddressModel, AddressDTO, int>, IAddressService
    {
        public AddressService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Addresss", userLogined) { }
    }

    public interface IAuthorService : IGenericService<Author, AuthorModel, AuthorDTO, int> { }
    public class AuthorService : GenericService<Author, AuthorModel, AuthorDTO, int>, IAuthorService
    {
        public AuthorService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Authors", userLogined) { }
    }

    public interface IBannerService : IGenericService<Banner, BannerModel, BannerDTO, int> { }
    public class BannerService : GenericService<Banner, BannerModel, BannerDTO, int>, IBannerService
    {
        public BannerService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Banners", userLogined) { }
    }

    public interface IBookService : IGenericService<Book, BookModel, BookDTO, int> { }
    public class BookService : GenericService<Book, BookModel, BookDTO, int>, IBookService
    {
        public BookService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Books", userLogined) { }
    }

    public interface IBookPartnerService : IGenericService<BookPartner, BookPartnerModel, BookPartnerDTO, int> { }
    public class BookPartnerService : GenericService<BookPartner, BookPartnerModel, BookPartnerDTO, int>, IBookPartnerService
    {
        public BookPartnerService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/BookPartners", userLogined) { }
    }

    public interface ICartService : IGenericService<Cart, CartModel, CartDTO, int> { }
    public class CartService : GenericService<Cart, CartModel, CartDTO, int>, ICartService
    {
        public CartService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Carts", userLogined) { }
    }

    public interface ICartItemService : IGenericService<CartItem, CartItemModel, CartItemDTO, int> { }
    public class CartItemService : GenericService<CartItem, CartItemModel, CartItemDTO, int>, ICartItemService
    {
        public CartItemService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/CartItems", userLogined) { }
    }

    public interface ICategoryService : IGenericService<Category, CategoryModel, CategoryDTO, int> { }
    public class CategoryService : GenericService<Category, CategoryModel, CategoryDTO, int>, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Categories", userLogined) { }
    }


    public interface ICoverTypeService : IGenericService<CoverType, CoverTypeModel, CoverTypeDTO, int> { }
    public class CoverTypeService : GenericService<CoverType, CoverTypeModel, CoverTypeDTO, int>, ICoverTypeService
    {
        public CoverTypeService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/CoverTypes", userLogined) { }
    }

    public interface IDimensionService : IGenericService<Dimension, DimensionModel, DimensionDTO, int> { }
    public class DimensionService : GenericService<Dimension, DimensionModel, DimensionDTO, int>, IDimensionService
    {
        public DimensionService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Dimensions", userLogined) { }
    }

    public interface IFavouriteService : IGenericService<Favourite, FavouriteModel, FavouriteDTO, int> { }
    public class FavouriteService : GenericService<Favourite, FavouriteModel, FavouriteDTO, int>, IFavouriteService
    {
        public FavouriteService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Favourites", userLogined) { }
    }

    public interface IFlashSaleService : IGenericService<FlashSale, FlashSaleModel, FlashSaleDTO, int> { }
    public class FlashSaleService : GenericService<FlashSale, FlashSaleModel, FlashSaleDTO, int>, IFlashSaleService
    {
        public FlashSaleService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/FlashSales", userLogined) { }
    }

    public interface IFlashSaleBookService : IGenericService<FlashSaleBook, FlashSaleBookModel, FlashSaleBookDTO, int> { }
    public class FlashSaleBookService : GenericService<FlashSaleBook, FlashSaleBookModel, FlashSaleBookDTO, int>, IFlashSaleBookService
    {
        public FlashSaleBookService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/FlashSaleBooks", userLogined) { }
    }

    public interface IMenuService : IGenericService<Menu, MenuModel, MenuDTO, int> { }
    public class MenuService : GenericService<Menu, MenuModel, MenuDTO, int>, IMenuService
    {
        public MenuService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Menus", userLogined) { }
    }

    public interface INotificationService : IGenericService<Notification, NotificationModel, NotificationDTO, int> { }
    public class NotificationService : GenericService<Notification, NotificationModel, NotificationDTO, int>, INotificationService
    {
        public NotificationService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Notifications", userLogined) { }
    }

    public interface INotificationTypeService : IGenericService<NotificationType, NotificationTypeModel, NotificationTypeDTO, int> { }
    public class NotificationTypeService : GenericService<NotificationType, NotificationTypeModel, NotificationTypeDTO, int>, INotificationTypeService
    {
        public NotificationTypeService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/NotificationTypes", userLogined) { }
    }

    public interface IOrderService : IGenericService<Order, OrderModel, OrderDTO, int> { }
    public class OrderService : GenericService<Order, OrderModel, OrderDTO, int>, IOrderService
    {
        public OrderService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Orders", userLogined) { }
    }

    public interface IOrderItemService : IGenericService<OrderItem, OrderItemModel, OrderItemDTO, int> { }
    public class OrderItemService : GenericService<OrderItem, OrderItemModel, OrderItemDTO, int>, IOrderItemService
    {
        public OrderItemService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/OrderItems", userLogined) { }
    }

    public interface IOrderStatusService : IGenericService<OrderStatus, OrderStatusModel, OrderStatusDTO, int> { }
    public class OrderStatusService : GenericService<OrderStatus, OrderStatusModel, OrderStatusDTO, int>, IOrderStatusService
    {
        public OrderStatusService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/OrderStatus", userLogined) { }
    }

    public interface IPartnerTypeService : IGenericService<PartnerType, PartnerTypeModel, PartnerTypeDTO, int> { }
    public class PartnerTypeService : GenericService<PartnerType, PartnerTypeModel, PartnerTypeDTO, int>, IPartnerTypeService
    {
        public PartnerTypeService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/PartnerTypes", userLogined) { }
    }

    public interface IPaymentService : IGenericService<Payment, PaymentModel, PaymentDTO, int> { }
    public class PaymentService : GenericService<Payment, PaymentModel, PaymentDTO, int>, IPaymentService
    {
        public PaymentService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Payments", userLogined) { }
    }

    public interface IPaymentMethodService : IGenericService<PaymentMethod, PaymentMethodModel, PaymentMethodDTO, int> { }
    public class PaymentMethodService : GenericService<PaymentMethod, PaymentMethodModel, PaymentMethodDTO, int>, IPaymentMethodService
    {
        public PaymentMethodService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/PaymentMethods", userLogined) { }
    }

    public interface IPlatformService : IGenericService<Platform, PlatformModel, PlatformDTO, int> { }
    public class PlatformService : GenericService<Platform, PlatformModel, PlatformDTO, int>, IPlatformService
    {
        public PlatformService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Platforms", userLogined) { }
    }

    public interface IPosterImageService : IGenericService<PosterImage, PosterImageModel, PosterImageDTO, int> { }
    public class PosterImageService : GenericService<PosterImage, PosterImageModel, PosterImageDTO, int>, IPosterImageService
    {
        public PosterImageService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/PosterImages", userLogined) { }
    }

    public interface IReviewService : IGenericService<Review, ReviewModel, ReviewDTO, int> { }
    public class ReviewService : GenericService<Review, ReviewModel, ReviewDTO, int>, IReviewService
    {
        public ReviewService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Reviews", userLogined) { }
    }

    public interface IStatusService : IGenericService<Status, StatusModel, StatusDTO, int> { }
    public class StatusService : GenericService<Status, StatusModel, StatusDTO, int>, IStatusService
    {
        public StatusService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Status", userLogined) { }
    }

    public interface ITopicService : IGenericService<Topic, TopicModel, TopicDTO, int> { }
    public class TopicService : GenericService<Topic, TopicModel, TopicDTO, int>, ITopicService
    {
        public TopicService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Topics", userLogined) { }
    }

    public interface ITopicContentService : IGenericService<TopicContent, TopicContentModel, TopicContentDTO, int> { }
    public class TopicContentService : GenericService<TopicContent, TopicContentModel, TopicContentDTO, int>, ITopicContentService
    {
        public TopicContentService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/TopicContents", userLogined) { }
    }

    public interface IVoucherService : IGenericService<Voucher, VoucherModel, VoucherDTO, int> { }
    public class VoucherService : GenericService<Voucher, VoucherModel, VoucherDTO, int>, IVoucherService
    {
        public VoucherService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Vouchers", userLogined) { }
    }

    public interface IWebsiteService : IGenericService<Website, WebsiteModel, WebsiteDTO, int> { }
    public class WebsiteService : GenericService<Website, WebsiteModel, WebsiteDTO, int>, IWebsiteService
    {
        public WebsiteService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Websites", userLogined) { }
    }

    public interface IUserService : IGenericService<AspNetUser, AspNetUserModel, AspNetUserDTO, string> { }
    public class UserService : GenericService<AspNetUser, AspNetUserModel, AspNetUserDTO, string>, IUserService
    {
        public UserService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Users", userLogined) { }
    }

    public interface IRoleService : IGenericService<AspNetRole, AspNetRoleModel, AspNetRoleDTO, string> { }
    public class RoleService : GenericService<AspNetRole, AspNetRoleModel, AspNetRoleDTO, string>, IRoleService
    {
        public RoleService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Roles", userLogined) { }
    }
    public interface IPartnerService : IGenericService<Partner, PartnerModel, PartnerDTO, int>
    {
    }
    public class PartnerService : GenericService<Partner, PartnerModel, PartnerDTO, int>, IPartnerService
    {
        public PartnerService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Partners", userLogined) { }

    }
    public interface ISubcategoryService : IGenericService<Subcategory, SubcategoryModel, SubcategoryDTO, int>
    {
    }
    public class SubcategoryService : GenericService<Subcategory, SubcategoryModel, SubcategoryDTO, int>, ISubcategoryService
    {
        public SubcategoryService(IHttpClientFactory httpClientFactory, UserLogined userLogined)
            : base(httpClientFactory, "https://localhost:7069/api/Subcategories", userLogined) { }

    }
}
