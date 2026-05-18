using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.CategoryDto
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
