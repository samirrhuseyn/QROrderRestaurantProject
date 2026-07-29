using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.SocialMediaDto;
using OrderRestaurant.EntityLayer.Entities;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                Color = createSocialMediaDto.Color,
                Icon = createSocialMediaDto.Icon,
                URL = createSocialMediaDto.URL
            };
            _socialMediaService.TAdd(socialMedia);
            return Ok("Created successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                SocialMediaId = updateSocialMediaDto.SocialMediaId,
                Color = updateSocialMediaDto.Color,
                Icon = updateSocialMediaDto.Icon,
                URL = updateSocialMediaDto.URL
            };
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Updated successfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }
    }
}
