using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurantWebUI.Dtos.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeatureID { get; set; }
        public string FeatureTitle { get; set; }
        public string FeatureDescription { get; set; }
    }
}
