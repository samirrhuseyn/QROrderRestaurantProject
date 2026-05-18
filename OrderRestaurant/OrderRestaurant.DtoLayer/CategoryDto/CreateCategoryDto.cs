using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.CategoryDto
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
