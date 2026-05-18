using AutoMapper;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DtoLayer.DiscountDto;

namespace OrderRestaurantAPI.Mapping
{
    public class DiscountMapper : Profile
    {
        public DiscountMapper()
        {
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();
        }
    }
}
