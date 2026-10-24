using OrderRestaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int CountOfOrdersToday();
        int CountOfConfirmedOrdersToday();
        int CountOfPendingOrdersToday();
        int CountOfPreparingOrdersToday();
        int CountOfReadyOrdersToday();
        int CountOfServedOrdersToday();
        int CountOfCompletedOrdersToday();
        int CountOfCancelledOrdersToday();
    }
}
