using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.CategoryDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category Category = new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                IsActive = true
            };
            _categoryService.TAdd(Category);
            return Ok("Created successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            _categoryService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category Category = new Category()
            {
                CategoryID = updateCategoryDto.CategoryID,
                CategoryName = updateCategoryDto.CategoryName,
                IsActive = true
            };
            _categoryService.TUpdate(Category);
            return Ok("Updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("Passive{id}")]
        public IActionResult ChangeIsPassive(int id)
        {
            var value = _categoryService.TGetById(id);
            value.IsActive = false;
            _categoryService.TUpdate(value);
            return Ok("The situation has changed: Passive!");
        }

        [HttpPut("Active{id}")]
        public IActionResult ChangeIsActive(int id)
        {
            var value = _categoryService.TGetById(id);
            value.IsActive = true;
            _categoryService.TUpdate(value);
            return Ok("The situation has changed: Active!");
        }
    }
}
