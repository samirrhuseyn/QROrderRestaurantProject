using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DataAccessLayer.Repositories;
using OrderRestaurant.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.EntityFramework
{
    public class EFOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EFOrderDal(OrderRestaurantContext context) : base(context)
        {
        }

        public int CountOfCancelledOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x=>x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Cancelled") ;
        }

        public int CountOfCompletedOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Completed");
        }

        public int CountOfConfirmedOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Confirmed");
        }

        public int CountOfOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Count(x=>x.DateTime.Day ==  DateTime.Now.Day);
        }

        public int CountOfPendingOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Pending");
        }

        public int CountOfPreparingOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Preparing");
        }

        public int CountOfReadyOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Ready");
        }

        public int CountOfServedOrdersToday()
        {
            using var context = new OrderRestaurantContext();
            return context.Orders.Where(x => x.DateTime.Day == DateTime.Now.Day).Count(x => x.Description == "Served");
        }
    }
}
