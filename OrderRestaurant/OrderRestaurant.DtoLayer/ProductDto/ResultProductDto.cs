using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.ProductDto
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
