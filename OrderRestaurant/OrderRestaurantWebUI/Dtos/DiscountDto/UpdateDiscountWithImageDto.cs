namespace OrderRestaurantWebUI.Dtos.DiscountDto
{
    public class UpdateDiscountWithImageDto
    {
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string Amount { get; set; }
        public string DiscountDescription { get; set; }
        public IFormFile? ImageURL { get; set; }
        public string ExistingImageUrl { get; set; }

    }
}
