namespace OrderRestaurantWebUI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
