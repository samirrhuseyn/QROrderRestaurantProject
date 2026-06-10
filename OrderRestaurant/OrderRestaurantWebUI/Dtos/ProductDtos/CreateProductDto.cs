namespace OrderRestaurantWebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }
        public int CategoryId { get; set; }
    }
}
