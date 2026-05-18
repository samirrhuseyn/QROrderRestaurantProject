using AutoMapper;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DtoLayer.BookingDto;

namespace OrderRestaurantAPI.Mapping
{
    public class BookingMapper : Profile
    {
        public BookingMapper()
        {
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
        }
    }
}
