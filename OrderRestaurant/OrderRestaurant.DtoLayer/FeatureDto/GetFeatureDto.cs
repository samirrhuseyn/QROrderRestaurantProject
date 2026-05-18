using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureID { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureDescription { get; set; }
    }
}
