using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.FeatureDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _featureService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature()
            {

                FeatureTitle = createFeatureDto.FeatureTitle,
                FeatureDescription = createFeatureDto.FeatureDescription
            };
            _featureService.TAdd(feature);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            _featureService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature()
            {
                FeatureID = updateFeatureDto.FeatureID,
                FeatureTitle = updateFeatureDto.FeatureTitle,
                FeatureDescription = updateFeatureDto.FeatureDescription
            };
            _featureService.TUpdate(feature);
            return Ok("Updated successfully!");
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}
