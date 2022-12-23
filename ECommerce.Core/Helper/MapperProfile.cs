using AutoMapper;
using ECommerce.Core.ViewModels;
using ECommerce.Domain.Models;

namespace ECommerce.Core.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}