using OrderRestaueant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.EntityLayer.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
