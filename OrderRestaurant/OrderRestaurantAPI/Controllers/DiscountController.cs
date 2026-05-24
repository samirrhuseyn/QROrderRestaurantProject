using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.DiscountDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountTitle = createDiscountDto.DiscountTitle,
                DiscountDescription = createDiscountDto.DiscountDescription,
                Amount = createDiscountDto.Amount,
                ImageURL = createDiscountDto.ImageURL
            };
            _discountService.TAdd(discount);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            _discountService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            Discount discount = new Discount()
            {
                DiscountId = updateDiscountDto.DiscountId,
                DiscountTitle = updateDiscountDto.DiscountTitle,
                DiscountDescription = updateDiscountDto.DiscountDescription,
                Amount = updateDiscountDto.Amount,
                ImageURL = updateDiscountDto.ImageURL
            };
            _discountService.TUpdate(discount);
            return Ok("Updated successfully!");
        }

        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }
    }
}
