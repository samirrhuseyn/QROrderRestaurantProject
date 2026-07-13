using OrderRestaueant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.BusinessLayer.Abstract
{
    public interface IAboutService : IGenericService<About>
    {
        About TGetLastAbout();
    }
}
