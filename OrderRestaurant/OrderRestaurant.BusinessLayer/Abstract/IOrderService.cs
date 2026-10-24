using OrderRestaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TCountOfOrdersToday();
        int TCountOfConfirmedOrdersToday();
        int TCountOfPendingOrdersToday();
        int TCountOfPreparingOrdersToday();
        int TCountOfReadyOrdersToday();
        int TCountOfServedOrdersToday();
        int TCountOfCompletedOrdersToday();
        int TCountOfCancelledOrdersToday();
    }
}
