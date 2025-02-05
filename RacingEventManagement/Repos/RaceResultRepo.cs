using RacingEventManagement.Models.Context;
using RacingEventManagement.Models;

namespace RacingEventManagement.Repos
{
    public class RaceResultRepo
    {
        private readonly RacingContext _dbContext;
        public RaceResultRepo(RacingContext context)
        {
            _dbContext = context;
        }

        public void AddRaceResult(RaceResult raceResult)
        {
            _dbContext.RacesResults.Add(raceResult);
            _dbContext.SaveChanges();
        }

        public void AddRaceResultUsingContextDirectly(RaceResult raceResult)
        {
            _dbContext.Add(raceResult);
            _dbContext.SaveChanges();
        }
    }
}
