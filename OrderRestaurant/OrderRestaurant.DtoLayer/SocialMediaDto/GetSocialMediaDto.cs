using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.SocialMediaDto
{
    public class GetSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
