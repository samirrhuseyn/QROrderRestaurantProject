using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DtoLayer.ContactDto
{
    public class CreateContactDto
    {
       public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FooterDescription { get; set; }
    }
}
