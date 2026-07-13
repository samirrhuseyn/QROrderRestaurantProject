namespace OrderRestaurantWebUI.Dtos.AboutDto
{
    public class UpdateAboutWithImageDto
    {
        public int AboutID { get; set; }
        public IFormFile? ImageURL { get; set; }
        public string ExistingImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
