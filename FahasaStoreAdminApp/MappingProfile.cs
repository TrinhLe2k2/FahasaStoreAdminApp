using AutoMapper;
using FahasaStoreAdminApp.Models.EntitiesModels;
using FahasaStoreAPI.Models.FormModels;

namespace FahasaStoreAdminApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookForm, BookEntities>().ReverseMap();
        }
    }
}
