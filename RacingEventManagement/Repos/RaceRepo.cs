using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RacingEventManagement.Models;
using RacingEventManagement.Models.Context;
using Formatting = Newtonsoft.Json.Formatting;

namespace RacingEventManagement.Repos
{
    public class RaceRepo
    {
        private readonly IDbContextFactory<RacingContext> _dbContextFactory;
        public RaceRepo(IDbContextFactory<RacingContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddRace(Race race)
        {

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

        public void TryUpdateHardCodedExistingRace()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var newLocation = "Australia";
                var race = new Race()
                {
                    Date = DateTime.Parse("2025-02-04 21:31:56.884946"),
                    Distance = 10,
                    Location = "Belgium",
                    Name = "Grand Prix Francorchamps",
                    RaceId = 1
                };

                race.Location = newLocation;
                Console.WriteLine("Se incearca un update la o enitate care o avem deja in DB dar aceasta entitate nu este tracked deci" +
                    "nu vom vedea o diferenta\n");

                context.SaveChangesAsync();

                Console.WriteLine("Detect changes:\n");
                context.ChangeTracker.DetectChanges();
                Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

                var raceFromDb = context.Races.Find(1);
                if (raceFromDb.Location.Equals(newLocation))
                    Console.WriteLine("Entity did update\n");
                else Console.WriteLine("Entity did not update as expected\n");
            }
        }

        public void UpdateRaceUsingFind()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var firstRace = context.Races.Find(1);

                Console.WriteLine("Race before update\n");
                Console.WriteLine(JsonConvert.SerializeObject(firstRace, Formatting.Indented));

                if (firstRace != null)
                {
                    firstRace.Location = "Budapest";

                    Console.WriteLine("Detect changes:\n");
                    context.ChangeTracker.DetectChanges();
                    Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

                    Console.WriteLine("Saving changes to DB\n");
                    context.SaveChangesAsync();

                    var updatedFirstRace = context.Races.Find(1);
                    Console.WriteLine("Race after update\n");
                    Console.WriteLine(JsonConvert.SerializeObject(updatedFirstRace, Formatting.Indented));
                }

            }
        }

        public void UpdateRaceUsingUpdate()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Console.WriteLine("trying to update database with an untracked object having the id of the entity from db that we want updated");

                var race = new Race()
                {
                    Date = DateTime.Parse("2025-02-04 21:31:56.884946"),
                    Distance = 10,
                    Location = "Kilimanjaro",
                    Name = "Grand Prix Francorchamps",
                    RaceId = 1
                };

                context.Update(race);
                context.SaveChanges();

                Console.WriteLine("After update\n");
                var updatedRace = context.Races.Find(1);
                Console.WriteLine("Updated race:\n");
                Console.WriteLine(JsonConvert.SerializeObject(updatedRace, Formatting.Indented));
                if (updatedRace != null)
                {
                    if (updatedRace.Location.Equals("Kilimanjaro"))
                    {
                        Console.WriteLine("Update worked\n");

                    }
                    else Console.WriteLine("Update did not work\n");
                }
            }
        }

        public void UpdateRaceUsingFindAndModifyObejctOutsideContextScope()
        {
            Race race = null;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                race = context.Races.Find(1);

                Console.WriteLine("Modifing name of race in context scope\n");
                race.Name = "Modified Name";
            }

            Console.WriteLine("Modifing distance of race outside context scope\n");
            race.Distance = 50;

            //new scope
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Console.WriteLine("Detect changes:\n");
                context.ChangeTracker.DetectChanges();
                Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

                Console.WriteLine("Saving changes\n");
                context.SaveChanges();

                Console.WriteLine("Updated race:\n");
                var updatedRace = context.Races.Find(1);
                Console.WriteLine(JsonConvert.SerializeObject(updatedRace, Formatting.Indented));


            }


            using (var context = _dbContextFactory.CreateDbContext())
            {

                Console.WriteLine("Attach race to new context and set its state as modified:\n");
                context.Entry(race).State = EntityState.Modified;

                Console.WriteLine("Saving changes\n");
                context.SaveChanges();

                Console.WriteLine("The now updated race:\n");
                var updatedRace = context.Races.Find(1);
                Console.WriteLine(JsonConvert.SerializeObject(updatedRace, Formatting.Indented));

            }
        }
    }
}
