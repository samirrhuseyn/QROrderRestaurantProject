namespace OrderRestaurantWebUI.Dtos.DiscountDto
{
    public class CreateDiscountWithImageDto
    {
        public string DiscountTitle { get; set; }
        public string Amount { get; set; }
        public string DiscountDescription { get; set; }
        public IFormFile ImageURL { get; set; }
    }
}
