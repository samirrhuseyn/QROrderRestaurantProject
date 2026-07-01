namespace OrderRestaurantWebUI.Dtos.ProductDtos
{
    public class UpdateProductWithImageDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ExistingImageUrl { get; set; }
        public IFormFile? ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
