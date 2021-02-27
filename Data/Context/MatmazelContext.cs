using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MatmazelContext : IdentityDbContext<AppUser,AppRole,int>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}