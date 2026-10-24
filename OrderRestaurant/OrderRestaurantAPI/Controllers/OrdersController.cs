using Microsoft.AspNetCore.Mvc;
using OrderRestaurant.BusinessLayer.Abstract;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("CountOfOrdersToday")]
        public IActionResult CountOfOrdersToday()
        {
            return Ok(_orderService.TCountOfOrdersToday());
        }

        [HttpGet("CountOfConfirmedOrdersToday")]
        public IActionResult CountOfConfirmedOrdersToday()
        {
            return Ok(_orderService.TCountOfConfirmedOrdersToday());
        }

        [HttpGet("CountOfPendingOrdersToday")]
        public IActionResult CountOfPendingOrdersToday()
        {
            return Ok(_orderService.TCountOfPendingOrdersToday());
        }

        [HttpGet("CountOfPreparingOrdersToday")]
        public IActionResult CountOfPreparingOrdersToday()
        {
            return Ok(_orderService.TCountOfPreparingOrdersToday());
        }

        [HttpGet("CountOfReadyOrdersToday")]
        public IActionResult CountOfReadyOrdersToday()
        {
            return Ok(_orderService.TCountOfReadyOrdersToday());
        }

        [HttpGet("CountOfServedOrdersToday")]
        public IActionResult CountOfServedOrdersToday()
        {
            return Ok(_orderService.TCountOfServedOrdersToday());
        }

        [HttpGet("CountOfCompletedOrdersToday")]
        public IActionResult CountOfCompletedOrdersToday()
        {
            return Ok(_orderService.TCountOfCompletedOrdersToday());
        }

        [HttpGet("CountOfCancelledOrdersToday")]
        public IActionResult CountOfCancelledOrdersToday()
        {
            return Ok(_orderService.TCountOfCancelledOrdersToday());
        }
    }
}
