using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurantWebUI.Dtos.AboutDto
{
    public class CreateAboutDto
    {
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
