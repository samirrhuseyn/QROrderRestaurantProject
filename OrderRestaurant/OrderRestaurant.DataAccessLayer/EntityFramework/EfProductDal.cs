using Microsoft.EntityFrameworkCore;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderRestaurant.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(OrderRestaurantContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context = new OrderRestaurantContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }
    }
}
