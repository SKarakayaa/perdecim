using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MatmazelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Server=dumbo.db.elephantsql.com;Database=ivmbfhft; User Id=ivmbfhft; Password=0mgT_JMz78NwVpKmiS9EbThNWNF-Eiry;Port=5432;", option => option.SetPostgresVersion(new System.Version(9, 6)));

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}