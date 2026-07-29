namespace OrderRestaurantWebUI.Dtos.TestimonialDto
{
    public class UpdateTestimonialWithImageDto
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public IFormFile? ImageURL { get; set; }
        public string ExistingImageUrl { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
