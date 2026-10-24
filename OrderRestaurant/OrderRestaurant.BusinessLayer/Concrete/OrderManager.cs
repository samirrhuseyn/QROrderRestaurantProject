using OrderRestaurant.BusinessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public int TCountOfCancelledOrdersToday()
        {
            return _orderDal.CountOfCancelledOrdersToday();
        }

        public int TCountOfCompletedOrdersToday()
        {
            return _orderDal.CountOfCompletedOrdersToday();
        }

        public int TCountOfConfirmedOrdersToday()
        {
            return _orderDal.CountOfConfirmedOrdersToday();
        }

        public int TCountOfOrdersToday()
        {
            return _orderDal.CountOfOrdersToday();
        }

        public int TCountOfPendingOrdersToday()
        {
            return _orderDal.CountOfPendingOrdersToday();
        }

        public int TCountOfPreparingOrdersToday()
        {
            return _orderDal.CountOfPreparingOrdersToday();
        }

        public int TCountOfReadyOrdersToday()
        {
            return _orderDal.CountOfReadyOrdersToday();
        }

        public int TCountOfServedOrdersToday()
        {
            return _orderDal.CountOfServedOrdersToday();
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
