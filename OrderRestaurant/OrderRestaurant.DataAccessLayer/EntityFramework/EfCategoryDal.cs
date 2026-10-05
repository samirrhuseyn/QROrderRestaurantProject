using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(OrderRestaurantContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new OrderRestaurantContext();
            return context.Categories.Where(x => x.IsActive == true).Count();
        }

        public int CategoryCount()
        {
            using var context = new OrderRestaurantContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new OrderRestaurantContext();
            return context.Categories.Where(x => x.IsActive == false).Count();
        }
    }
}
