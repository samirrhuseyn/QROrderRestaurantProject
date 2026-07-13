using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.AboutDro;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageURL = createAboutDto.ImageURL
            };
            _aboutService.TAdd(about);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                AboutID = updateAboutDto.AboutID,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageURL = updateAboutDto.ImageURL
            };
            _aboutService.TUpdate(about);
            return Ok("Updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetLastAbout")]
        public IActionResult GetLastAbout()
        {
            var value = _aboutService.TGetLastAbout();
            return Ok(value);
        }
    }
}
