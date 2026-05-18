using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.CategoryDto
{
    public class GetCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
