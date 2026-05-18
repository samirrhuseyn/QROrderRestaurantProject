using AutoMapper;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DtoLayer.AboutDro;

namespace OrderRestaurantAPI.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
                CreateMap<About,ResultAboutDto>().ReverseMap();
                CreateMap<About,CreateAboutDto>().ReverseMap();
                CreateMap<About,UpdateAboutDto>().ReverseMap();
                CreateMap<About,GetAboutDto>().ReverseMap();
        }
    }
}
