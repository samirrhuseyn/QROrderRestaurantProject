using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.DataAccessLayer.Abstract;
using OrderRestaurant.DataAccessLayer.Concrete;
using OrderRestaurant.DataAccessLayer.Repositories;

namespace OrderRestaurant.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        private readonly OrderRestaurantContext _context;
        public EfAboutDal(OrderRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public About GetLastAbout()
        {
            return _context.Abouts
                       .OrderByDescending(x => x.AboutID)
                       .FirstOrDefault();
        }
    }
}
