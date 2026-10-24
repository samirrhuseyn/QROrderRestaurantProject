using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DataAccessLayer.Repositories;
using OrderRestaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.EntityFramework
{
    public class EFOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EFOrderDetailDal(OrderRestaurantContext context) : base(context)
        {
        }
    }
}
