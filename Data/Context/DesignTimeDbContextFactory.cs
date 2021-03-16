using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<MatmazelContext>
    {
        public MatmazelContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MatmazelContext>();
            var connectionString = "Server=161.35.219.52;Database=perdecim; User Id=skarakaya; Password=10117Sefa.; Port=5432;";
            builder.UseNpgsql(connectionString);
            return new MatmazelContext(builder.Options);
        }
    }
}