using AutoMapper;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Core.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<SellPost, SellPostViewModel>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();
            CreateMap<IdentityUser, AspNetUsersViewModel> ().ReverseMap();
            CreateMap<SellPostWiseTag, SellPostWiseTagViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<Message, MessageViewModel>().ReverseMap();
            CreateMap<UserBlockList, UserBlockListViewModel>().ReverseMap();
        }
    }
}