using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RacingEventManagement.Models;
using RacingEventManagement.Models.Context;

namespace RacingEventManagement.Repos
{
    public class ParticipantRepo
    {
        private readonly IDbContextFactory<RacingContext> _dbContextFactory;
        public ParticipantRepo(IDbContextFactory<RacingContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void AddSomeParticipants()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var participants = new List<Participant>
                {
                    new() { FirstName = "Lewis", LastName = "Hamilton", Team = "Mercedes", ExperienceYears = 16 },
                    new() { FirstName = "Max", LastName = "Verstappen", Team = "Red Bull Racing", ExperienceYears = 10 },
                    new() { FirstName = "Charles", LastName = "Leclerc", Team = "Ferrari", ExperienceYears = 6 },
                    new() { FirstName = "Lando", LastName = "Norris", Team = "McLaren", ExperienceYears = 5 }
                };

                context.Participants.AddRange(participants); 
                context.SaveChanges();
            }
        }

        public void UpdateWithoutSaveChanges()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Participant p1 = new() { ParticipantId = 1, FirstName = "Lewis", LastName = "HAMilton", Team = "Mercedes", ExperienceYears = 3 };
                context.Participants.Update(p1);
            }

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var retrievedP1 = context.Participants.Find(1);
                Console.WriteLine("The player 1 retrieved and non Updated:\n");
                Console.WriteLine(JsonConvert.SerializeObject(retrievedP1, Formatting.Indented));
            }
        }

        public void UpdateWithExecuteUpdate()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Participant p1 = new() { ParticipantId = 1, FirstName = "Lewis", LastName = "HAMilton", Team = "Mercedes", ExperienceYears = 3 };

                context.Participants
                    .Where(p => p.ParticipantId == p1.ParticipantId)
                    .ExecuteUpdate(setters => setters
                        .SetProperty(p => p.FirstName, p1.FirstName)
                        .SetProperty(p => p.LastName, p1.LastName)
                        .SetProperty(p => p.Team, p1.Team)
                        .SetProperty(p => p.ExperienceYears, p1.ExperienceYears)
                    );
            }

            using (var context = _dbContextFactory.CreateDbContext())
            {
                var retrievedP1 = context.Participants.Find(1);
                Console.WriteLine("The player 1 retrieved and Updated:\n");
                Console.WriteLine(JsonConvert.SerializeObject(retrievedP1, Formatting.Indented));
            }
        }

        public void UpdateParticipantTeamUnsecure(int participantId, string newTeam)
        {
            Console.WriteLine("Updating Participant's team using UNSAFE method.\n");

            using (var context = _dbContextFactory.CreateDbContext())
            {
                string query = $"UPDATE Participants SET Team = '{newTeam}' WHERE ParticipantId = {participantId}";
                context.Database.ExecuteSqlRaw(query);
            }

            Console.WriteLine("Update completed, risk of sql INJECTION\n");
        }

        public void UpdateParticipantTeamSecure(int participantId, string newTeam)
        {
            Console.WriteLine("Updating Participant's team using SAFE method.\n");

            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Database.ExecuteSqlRaw(
                    "UPDATE Participants SET Team = @p0 WHERE ParticipantId = @p1",
                    newTeam, participantId
                );
            }

            Console.WriteLine("Update with success");
        }

        public void GetParticipantsEagerLoading()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var participants = context.Participants.ToList();

                foreach (var participant in participants)
                {
                    Console.WriteLine($"Participant: {participant.FirstName} {participant.LastName}, Team: {participant.Team}");
                }

                Console.WriteLine("This approach uses more memory if the list o participants is large");
                Console.WriteLine("More optimal, single database query");
            }
        }

        public void GetParticipantsLazyLoading()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var participants = context.Participants.AsQueryable(); // No immediate execution

                foreach (var participant in participants)
                {
                    Console.WriteLine($"Participant: {participant.FirstName} {participant.LastName}, Team: {participant.Team}");
                }

                Console.WriteLine("This approach is more memory efficient");
                Console.WriteLine("KEEPS the db connection open for the duration of the loop => might cause" +
                    "data incosistency if data is changed in the meanwhile");
            }
        }
    }
}
