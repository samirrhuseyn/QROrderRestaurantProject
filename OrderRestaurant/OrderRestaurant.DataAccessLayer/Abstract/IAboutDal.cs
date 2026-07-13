using OrderRestaueant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        About GetLastAbout();
    }
}
