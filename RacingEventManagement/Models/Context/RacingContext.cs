using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
namespace RacingEventManagement.Models.Context
{
    public class RacingContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Race> Races { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            optionsBuilder.UseMySql("server=127.0.0.1;database=RacingEventDb;user=root;password=root;", new MySqlServerVersion(new Version(8, 0, 28)));
            //optionsBuilder.("server=your_ip;database=RacingEventDb;user=root;password=root;");
            //optionsBuilder.UseSqlServer("server=127.0.0.1;database=RacingEventDb;user=root;password=root;");
        }

    }
}
