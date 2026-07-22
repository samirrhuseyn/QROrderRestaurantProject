namespace OrderRestaurantWebUI.Dtos.TestimonialDto
{
    public class CreateTestimonialWithImageDto
    {
        public string Name { get; set; }
        public IFormFile ImageURL { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
