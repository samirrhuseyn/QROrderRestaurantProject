namespace OrderRestaurant.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
