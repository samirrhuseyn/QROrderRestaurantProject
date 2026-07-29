using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.TestimonialDto;
using OrderRestaurant.EntityLayer.Entities;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                Name = createTestimonialDto.Name,
                Comment = createTestimonialDto.Comment,
                IsActive = true,
                ImageURL = createTestimonialDto.ImageURL
            };
            _testimonialService.TAdd(testimonial);
            return Ok("Created successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                Name = updateTestimonialDto.Name,
                Comment = updateTestimonialDto.Comment,
                IsActive = true,
                ImageURL = updateTestimonialDto.ImageURL
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpPut("Passive{id}")]
        public IActionResult ChangeIsPassive(int id)
        {
            var value = _testimonialService.TGetById(id);
            value.IsActive = false;
            _testimonialService.TUpdate(value);
            return Ok("The situation has changed: Passive!");
        }

        [HttpPut("Active{id}")]
        public IActionResult ChangeIsActive(int id)
        {
            var value = _testimonialService.TGetById(id);
            value.IsActive = true;
            _testimonialService.TUpdate(value);
            return Ok("The situation has changed: Active!");
        }
    }
}
