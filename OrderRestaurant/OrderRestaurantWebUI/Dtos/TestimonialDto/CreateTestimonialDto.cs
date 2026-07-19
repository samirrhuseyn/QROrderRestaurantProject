using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurantWebUI.Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
