using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MatmazelContext : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}