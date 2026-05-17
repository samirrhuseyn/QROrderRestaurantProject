using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.EntityLayer.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string URL { get; set; }
    }
}
