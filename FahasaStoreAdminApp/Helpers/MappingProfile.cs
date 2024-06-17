using AutoMapper;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Models.DTO;
using FahasaStoreAdminApp.Models.Response;

namespace FahasaStoreAdminApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaginatedResponse, PaginatedResponse<AddressDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<AuthorDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<BannerDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<BookDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<BookPartnerDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<CartDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<CartItemDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<CategoryDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<SubcategoryDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<CoverTypeDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<DimensionDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<FavouriteDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<FlashSaleDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<FlashSaleBookDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<MenuDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<NotificationDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<NotificationTypeDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<OrderDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<OrderItemDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<OrderStatusDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PartnerDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PartnerTypeDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PaymentDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PaymentMethodDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PlatformDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<PosterImageDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<ReviewDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<StatusDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<TopicDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<TopicContentDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<VoucherDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<WebsiteDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<AspNetUserDTO>>().ReverseMap();
            CreateMap<PaginatedResponse, PaginatedResponse<AspNetRoleDTO>>().ReverseMap();

            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Author, AuthorModel>().ReverseMap();
            CreateMap<Banner, BannerModel>().ReverseMap();
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<BookPartner, BookPartnerModel>().ReverseMap();
            CreateMap<Cart, CartModel>().ReverseMap();
            CreateMap<CartItem, CartItemModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Subcategory, SubcategoryModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeModel>().ReverseMap();
            CreateMap<Dimension, DimensionModel>().ReverseMap();
            CreateMap<Favourite, FavouriteModel>().ReverseMap();
            CreateMap<FlashSale, FlashSaleModel>().ReverseMap();
            CreateMap<FlashSaleBook, FlashSaleBookModel>().ReverseMap();
            CreateMap<Menu, MenuModel>().ReverseMap();
            CreateMap<Notification, NotificationModel>().ReverseMap();
            CreateMap<NotificationType, NotificationTypeModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<OrderItem, OrderItemModel>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusModel>().ReverseMap();
            CreateMap<Partner, PartnerModel>().ReverseMap();
            CreateMap<PartnerType, PartnerTypeModel>().ReverseMap();
            CreateMap<Payment, PaymentModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodModel>().ReverseMap();
            CreateMap<Platform, PlatformModel>().ReverseMap();
            CreateMap<PosterImage, PosterImageModel>().ReverseMap();
            CreateMap<Review, ReviewModel>().ReverseMap();
            CreateMap<Status, StatusModel>().ReverseMap();
            CreateMap<Topic, TopicModel>().ReverseMap();
            CreateMap<TopicContent, TopicContentModel>().ReverseMap();
            CreateMap<Voucher, VoucherModel>().ReverseMap();
            CreateMap<Website, WebsiteModel>().ReverseMap();
            CreateMap<AspNetUser, AspNetUserModel>().ReverseMap();
            CreateMap<AspNetRole, AspNetRoleModel>().ReverseMap();
        }
    }
}
