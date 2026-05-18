using AutoMapper;
using OrderRestaurant.DtoLayer.ContactDto;

namespace OrderRestaurantAPI.Mapping
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<ContactMapper,ResultContactDto>().ReverseMap();
            CreateMap<ContactMapper,CreateContactDto>().ReverseMap();
            CreateMap<ContactMapper,GetContactDto>().ReverseMap();
            CreateMap<ContactMapper,UpdateContactDto>().ReverseMap();
        }
    }
}
