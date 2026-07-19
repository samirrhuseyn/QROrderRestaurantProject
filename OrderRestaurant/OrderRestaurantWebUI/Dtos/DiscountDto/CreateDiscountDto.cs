using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurantWebUI.Dtos.DiscountDto
{
    public class CreateDiscountDto
    {
        public string DiscountTitle { get; set; }
        public string Amount { get; set; }
        public string DiscountDescription { get; set; }
        public string ImageURL { get; set; }
    }
}
