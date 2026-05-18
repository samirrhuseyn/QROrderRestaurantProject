using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.BookingDto
{
    public class CreateBookingDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string BookingStatus { get; set; }
    }
}
