

using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Models.EModels;
using Newtonsoft.Json;
using System.Net.Http;

namespace FahasaStoreAdminApp.Services.EntityService
{
    public interface IAddressService : IGenericService<Address, AddressModel, int> { }
    public class AddressService : GenericService<Address, AddressModel, int>, IAddressService
    {
        public AddressService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Addresss") { }
    }

    public interface IAuthorService : IGenericService<Author, AuthorModel, int> { }
    public class AuthorService : GenericService<Author, AuthorModel, int>, IAuthorService
    {
        public AuthorService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Authors") { }
    }

    public interface IBannerService : IGenericService<Banner, BannerModel, int> { }
    public class BannerService : GenericService<Banner, BannerModel, int>, IBannerService
    {
        public BannerService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Banners") { }
    }

    public interface IBookService : IGenericService<Book, BookModel, int> { }
    public class BookService : GenericService<Book, BookModel, int>, IBookService
    {
        public BookService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Books") { }
    }

    public interface IBookPartnerService : IGenericService<BookPartner, BookPartnerModel, int> { }
    public class BookPartnerService : GenericService<BookPartner, BookPartnerModel, int>, IBookPartnerService
    {
        public BookPartnerService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/BookPartners") { }
    }

    public interface ICartService : IGenericService<Cart, CartModel, int> { }
    public class CartService : GenericService<Cart, CartModel, int>, ICartService
    {
        public CartService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Carts") { }
    }

    public interface ICartItemService : IGenericService<CartItem, CartItemModel, int> { }
    public class CartItemService : GenericService<CartItem, CartItemModel, int>, ICartItemService
    {
        public CartItemService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/CartItems") { }
    }

    public interface ICategoryService : IGenericService<Category, CategoryModel, int> { }
    public class CategoryService : GenericService<Category, CategoryModel, int>, ICategoryService
    {
        public CategoryService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Categories") { }
    }


    public interface ICoverTypeService : IGenericService<CoverType, CoverTypeModel, int> { }
    public class CoverTypeService : GenericService<CoverType, CoverTypeModel, int>, ICoverTypeService
    {
        public CoverTypeService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/CoverTypes") { }
    }

    public interface IDimensionService : IGenericService<Dimension, DimensionModel, int> { }
    public class DimensionService : GenericService<Dimension, DimensionModel, int>, IDimensionService
    {
        public DimensionService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Dimensions") { }
    }

    public interface IFavouriteService : IGenericService<Favourite, FavouriteModel, int> { }
    public class FavouriteService : GenericService<Favourite, FavouriteModel, int>, IFavouriteService
    {
        public FavouriteService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Favourites") { }
    }

    public interface IFlashSaleService : IGenericService<FlashSale, FlashSaleModel, int> { }
    public class FlashSaleService : GenericService<FlashSale, FlashSaleModel, int>, IFlashSaleService
    {
        public FlashSaleService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/FlashSales") { }
    }

    public interface IFlashSaleBookService : IGenericService<FlashSaleBook, FlashSaleBookModel, int> { }
    public class FlashSaleBookService : GenericService<FlashSaleBook, FlashSaleBookModel, int>, IFlashSaleBookService
    {
        public FlashSaleBookService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/FlashSaleBooks") { }
    }

    public interface IMenuService : IGenericService<Menu, MenuModel, int> { }
    public class MenuService : GenericService<Menu, MenuModel, int>, IMenuService
    {
        public MenuService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Menus") { }
    }

    public interface INotificationService : IGenericService<Notification, NotificationModel, int> { }
    public class NotificationService : GenericService<Notification, NotificationModel, int>, INotificationService
    {
        public NotificationService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Notifications") { }
    }

    public interface INotificationTypeService : IGenericService<NotificationType, NotificationTypeModel, int> { }
    public class NotificationTypeService : GenericService<NotificationType, NotificationTypeModel, int>, INotificationTypeService
    {
        public NotificationTypeService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/NotificationTypes") { }
    }

    public interface IOrderService : IGenericService<Order, OrderModel, int> { }
    public class OrderService : GenericService<Order, OrderModel, int>, IOrderService
    {
        public OrderService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Orders") { }
    }

    public interface IOrderItemService : IGenericService<OrderItem, OrderItemModel, int> { }
    public class OrderItemService : GenericService<OrderItem, OrderItemModel, int>, IOrderItemService
    {
        public OrderItemService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/OrderItems") { }
    }

    public interface IOrderStatusService : IGenericService<OrderStatus, OrderStatusModel, int> { }
    public class OrderStatusService : GenericService<OrderStatus, OrderStatusModel, int>, IOrderStatusService
    {
        public OrderStatusService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/OrderStatus") { }
    }

    public interface IPartnerTypeService : IGenericService<PartnerType, PartnerTypeModel, int> { }
    public class PartnerTypeService : GenericService<PartnerType, PartnerTypeModel, int>, IPartnerTypeService
    {
        public PartnerTypeService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/PartnerTypes") { }
    }

    public interface IPaymentService : IGenericService<Payment, PaymentModel, int> { }
    public class PaymentService : GenericService<Payment, PaymentModel, int>, IPaymentService
    {
        public PaymentService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Payments") { }
    }

    public interface IPaymentMethodService : IGenericService<PaymentMethod, PaymentMethodModel, int> { }
    public class PaymentMethodService : GenericService<PaymentMethod, PaymentMethodModel, int>, IPaymentMethodService
    {
        public PaymentMethodService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/PaymentMethods") { }
    }

    public interface IPlatformService : IGenericService<Platform, PlatformModel, int> { }
    public class PlatformService : GenericService<Platform, PlatformModel, int>, IPlatformService
    {
        public PlatformService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Platforms") { }
    }

    public interface IPosterImageService : IGenericService<PosterImage, PosterImageModel, int> { }
    public class PosterImageService : GenericService<PosterImage, PosterImageModel, int>, IPosterImageService
    {
        public PosterImageService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/PosterImages") { }
    }

    public interface IReviewService : IGenericService<Review, ReviewModel, int> { }
    public class ReviewService : GenericService<Review, ReviewModel, int>, IReviewService
    {
        public ReviewService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Reviews") { }
    }

    public interface IStatusService : IGenericService<Status, StatusModel, int> { }
    public class StatusService : GenericService<Status, StatusModel, int>, IStatusService
    {
        public StatusService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Status") { }
    }

    public interface ITopicService : IGenericService<Topic, TopicModel, int> { }
    public class TopicService : GenericService<Topic, TopicModel, int>, ITopicService
    {
        public TopicService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Topics") { }
    }

    public interface ITopicContentService : IGenericService<TopicContent, TopicContentModel, int> { }
    public class TopicContentService : GenericService<TopicContent, TopicContentModel, int>, ITopicContentService
    {
        public TopicContentService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/TopicContents") { }
    }

    public interface IVoucherService : IGenericService<Voucher, VoucherModel, int> { }
    public class VoucherService : GenericService<Voucher, VoucherModel, int>, IVoucherService
    {
        public VoucherService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Vouchers") { }
    }

    public interface IWebsiteService : IGenericService<Website, WebsiteModel, int> { }
    public class WebsiteService : GenericService<Website, WebsiteModel, int>, IWebsiteService
    {
        public WebsiteService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Websites") { }
    }

    public interface IUserService : IGenericService<AspNetUser, AspNetUserModel, string> { }
    public class UserService : GenericService<AspNetUser, AspNetUserModel, string>, IUserService
    {
        public UserService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Users") { }
    }

    public interface IRoleService : IGenericService<AspNetRole, AspNetRoleModel, string> { }
    public class RoleService : GenericService<AspNetRole, AspNetRoleModel, string>, IRoleService
    {
        public RoleService(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "https://localhost:7069/api/Roles") { }
    }
}
