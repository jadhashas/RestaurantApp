using AutoMapper;
using RestaurantApp.Application.ViewModels;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Restaurant, RestaurantViewModel>().ReverseMap();
        }
    }
}
