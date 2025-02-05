using Microsoft.EntityFrameworkCore;
using RacingEventManagement.Models;
using RacingEventManagement.Models.Context;

namespace RacingEventManagement.Repos
{
    public class RaceRepo
    {
        private readonly RacingContext _dbContext;
        public RaceRepo(RacingContext context) {
        _dbContext = context;
                }

        public void AddRace(Race race) { 
            _dbContext.Races.Add(race);
            _dbContext.SaveChanges();
        }

        public List<Race> GetAllRaces()
        {
            var result = _dbContext.Races.ToList();
            return result;
        }
    }
}
