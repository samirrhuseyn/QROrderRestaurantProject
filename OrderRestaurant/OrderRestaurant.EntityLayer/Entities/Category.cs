namespace OrderRestaueant.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Products { get; set; }
    }
}
