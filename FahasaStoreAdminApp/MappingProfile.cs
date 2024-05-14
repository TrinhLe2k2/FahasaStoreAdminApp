using AutoMapper;
using FahasaStoreAPI.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressEntities, AddressForm>().ReverseMap();
            CreateMap<AuthorEntities, AuthorForm>().ReverseMap();
            CreateMap<BannerEntities, BannerForm>().ReverseMap();
            CreateMap<CoverTypeEntities, CoverTypeForm>().ReverseMap();
            CreateMap<BookEntities, BookForm>().ReverseMap();
            CreateMap<CartEntities, CartForm>().ReverseMap();
            CreateMap<CartItemEntities, CartItemForm>().ReverseMap();
            CreateMap<CategoryEntities, CategoryForm>().ReverseMap();
            CreateMap<DimensionEntities, DimensionForm>().ReverseMap();
            CreateMap<FlashSaleEntities, FlashSaleForm>().ReverseMap();
            CreateMap<FlashSaleBookEntities, FlashSaleBookForm>().ReverseMap();
            CreateMap<HelpEntities, HelpForm>().ReverseMap();
            CreateMap<HelpContentEntities, HelpContentForm>().ReverseMap();
            CreateMap<MenuEntities, MenuForm>().ReverseMap();
            CreateMap<NotificationEntities, NotificationForm>().ReverseMap();
            CreateMap<NotificationTypeEntities, NotificationTypeForm>().ReverseMap();
            CreateMap<OrderEntities, OrderForm>().ReverseMap();
            CreateMap<OrderItemEntities, OrderItemForm>().ReverseMap();
            CreateMap<OrderStatusEntities, OrderStatusForm>().ReverseMap();
            CreateMap<PartnerEntities, PartnerForm>().ReverseMap();
            CreateMap<PartnerTypeEntities, PartnerTypeForm>().ReverseMap();
            CreateMap<PaymentEntities, PaymentForm>().ReverseMap();
            CreateMap<PaymentMethodEntities, PaymentMethodForm>().ReverseMap();
            CreateMap<PosterImageEntities, PosterImageForm>().ReverseMap();
            CreateMap<ReviewEntities, ReviewForm>().ReverseMap();
            CreateMap<RoleEntities, RoleForm>().ReverseMap();
            CreateMap<SocialMediaLinkEntities, SocialMediaLinkForm>().ReverseMap();
            CreateMap<StatusEntities, StatusForm>().ReverseMap();
            CreateMap<SubcategoryEntities, SubcategoryForm>().ReverseMap();
            CreateMap<UserEntities, UserForm>().ReverseMap();
            CreateMap<VoucherEntities, VoucherForm>().ReverseMap();
            CreateMap<WebsiteEntities, WebsiteForm>().ReverseMap();
        }
    }
}
