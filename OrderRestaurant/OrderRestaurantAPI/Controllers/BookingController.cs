using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DtoLayer.AboutDro;
using OrderRestaurant.DtoLayer.BookingDto;

namespace OrderRestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Date = createBookingDto.Date,
                BookingStatus = createBookingDto.BookingStatus,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                PhoneNumber = createBookingDto.PhoneNumber
            };
            _bookingService.TAdd(booking);
            return Ok("Created successfully!");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok("Deleted successfully!");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingId = updateBookingDto.BookingId,
                Name = updateBookingDto.Name,
                Date = updateBookingDto.Date,
                BookingStatus = updateBookingDto.BookingStatus,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                PhoneNumber = updateBookingDto.PhoneNumber
            };
            _bookingService.TUpdate(booking);
            return Ok("Updated successfully!");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
