using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace e_commerceApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<AddressDtoForInsertion, Address>();
            CreateMap<UserDtoForCreation, IdentityUser>();
             CreateMap<userDtoForUpdate, IdentityUser>().ReverseMap();
             CreateMap<CommentDtoForCreation, Comment>();

        }
    }
}