namespace OrderRestaurantWebUI.Dtos.AboutDto
{
    public class CreateAboutWithImage
    {
        public IFormFile ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
