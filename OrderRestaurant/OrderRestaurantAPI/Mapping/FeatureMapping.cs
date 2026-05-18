using AutoMapper;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DtoLayer.FeatureDto;

namespace OrderRestaurantAPI.Mapping
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
        }
    }
}
