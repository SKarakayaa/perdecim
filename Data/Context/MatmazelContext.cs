using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MatmazelContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public MatmazelContext(DbContextOptions<MatmazelContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<DemandType> DemandTypes { get; set; }
        public DbSet<Demand> Demands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDemand> ProductDemands { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDemand> OrderDemands { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserCoupon> UserCoupons { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }

    }
}