using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MatmazelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Server=37.148.212.91;Database=perdecim; User Id=postgres; Password=postgres;Port=5432;");

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