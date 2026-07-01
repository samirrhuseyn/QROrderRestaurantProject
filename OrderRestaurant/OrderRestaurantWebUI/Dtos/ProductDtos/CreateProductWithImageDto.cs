namespace OrderRestaurantWebUI.Dtos.ProductDtos
{
    public class CreateProductWithImageDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public IFormFile ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
