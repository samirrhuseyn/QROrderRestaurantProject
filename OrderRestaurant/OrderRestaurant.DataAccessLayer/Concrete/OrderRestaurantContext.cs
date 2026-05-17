using Microsoft.EntityFrameworkCore;
using OrderRestaueant.EntityLayer.Entities;
using OrderRestaurant.EntityLayer.Entities;

namespace OrderRestaurant.DataAccessLayer.Concrete
{
    public class OrderRestaurantContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TVI51E6; initial Catalog=OrderRestaurantDb; integrated Security=true; TrustServerCertificate=True");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

    }
}
