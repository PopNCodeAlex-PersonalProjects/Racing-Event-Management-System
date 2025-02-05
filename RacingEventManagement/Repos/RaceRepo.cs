using Microsoft.EntityFrameworkCore;
using RacingEventManagement.Models;
using RacingEventManagement.Models.Context;

namespace RacingEventManagement.Repos
{
    public class RaceRepo
    {
        private readonly IDbContextFactory<RacingContext> _dbContextFactory;
        public RaceRepo(IDbContextFactory<RacingContext> dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }

        public void AddRace(Race race) { 
           
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Races.Add(race);
                context.SaveChanges();
            }
        }

        public List<Race> GetAllRaces()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var result = context.Races.ToList();
                return result;
            }
        }
    }
}
