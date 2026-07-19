using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.TestimonialDto
{
    public class ResultTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
