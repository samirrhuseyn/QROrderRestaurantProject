using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.DiscountDto
{
    public class CreateDiscountDto
    {
        public string DiscountTitle { get; set; }
        public string Amount { get; set; }
        public string DiscountDescription { get; set; }
        public string ImageURL { get; set; }
    }
}
