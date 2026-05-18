using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.AboutDro
{
    public class UpdateAboutDto
    {
        public int AboutID { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
