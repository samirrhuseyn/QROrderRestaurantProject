namespace OrderRestaueant.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string Amount { get; set; }
        public string DiscountDescription { get; set; }
        public string ImageURL { get; set; }
    }
}
