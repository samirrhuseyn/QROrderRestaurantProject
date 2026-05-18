using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
