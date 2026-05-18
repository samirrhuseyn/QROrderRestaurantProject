using AutoMapper;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DtoLayer.CategoryDto;

namespace OrderRestaurantAPI.Mapping
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
