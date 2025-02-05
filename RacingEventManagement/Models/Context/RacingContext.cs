using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
namespace RacingEventManagement.Models.Context
{
    public class RacingContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceResult> RacesResults { get; set; }

    }
}
