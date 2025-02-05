using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RacingEventManagement.Models.Context
{
    public class RacingContextFactory : IDesignTimeDbContextFactory<RacingContext>
    {
        public RacingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RacingContext>();
            optionsBuilder.UseMySql("server=127.0.0.1;database=RacingEventDb;user=root;password=root;",
                new MySqlServerVersion(new Version(8, 0, 28)));

            return new RacingContext(optionsBuilder.Options);
        }
    }
}
