using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class DesignTimeDbContextFactory:IDesignTimeDbContextFactory<MatmazelContext>
    {
        public MatmazelContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MatmazelContext>();
            var connectionString = "Server=167.172.186.80;Database=perdecim; User Id=perdecimuser; Password=H}WuON<QXIIGfX; Port=5432;";
            builder.UseNpgsql(connectionString);
            return new MatmazelContext(builder.Options);
        }
    }
}