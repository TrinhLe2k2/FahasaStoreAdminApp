using AutoMapper;
using BookStoreAPI.Services;
using FahasaStoreAdminApp.Entities;
using FahasaStoreAdminApp.Helpers;
using FahasaStoreAdminApp.Models.EModels;
using FahasaStoreAdminApp.Services.EntityService;

namespace FahasaStoreAdminApp.Controllers
{
    public class AuthorsController : GenericController<Author, AuthorModel, int>
    {
        private readonly IAuthorService _AuthorService;
        public AuthorsController(IAuthorService AuthorService, IMapper mapper, IImageUploader imageUploader) : base(AuthorService, mapper, imageUploader)
        {
            _AuthorService = AuthorService;
        }
    }
}
