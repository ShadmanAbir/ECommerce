using AutoMapper;
using ECommerce.API.Models;
using ECommerce.API.ViewModels;

namespace ECommerce.API.Helpers
{
    public class MapperProfile : Profile
    {
        MapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Attributes, opt => opt.MapFrom(src => src.Attributes.RootElement.ToString()));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
        }
    }
}
