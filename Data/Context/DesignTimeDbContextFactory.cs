using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<MatmazelContext>
    {
        public MatmazelContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MatmazelContext>();
            var connectionString = "Server=37.148.212.91;Database=perdecim; User Id=postgres; Password=1234;Port=5432;";
            builder.UseNpgsql(connectionString);
            return new MatmazelContext(builder.Options);
        }
    }
}