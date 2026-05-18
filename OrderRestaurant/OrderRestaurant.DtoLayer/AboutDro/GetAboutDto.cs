using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.AboutDro
{
    public class GetAboutDto
    {
        public int AboutID { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
