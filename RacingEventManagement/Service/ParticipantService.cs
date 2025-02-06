using RacingEventManagement.Repos;

namespace RacingEventManagement.Service
{
    public class ParticipantService
    {
        private static ParticipantRepo _repo;
        public ParticipantService(ParticipantRepo participantRepo)
        {
            _repo = participantRepo;
        }

        public void AddParticipantsAndModifyThem()
        {
            //Console.WriteLine("\n\    n\n\n\nAddSomeParticipants");
            //_repo.AddSomeParticipants();

            Console.WriteLine("\n\n\n\n\nUpdateWithoutSaveChanges");
            _repo.UpdateWithoutSaveChanges();

            Console.WriteLine("\n\n\n\n\nUpdateWithExecuteUpdate");
            _repo.UpdateWithExecuteUpdate();

            Console.WriteLine("\n\n\n\n\nUpdateParticipantTeamUnsecure");
            _repo.UpdateParticipantTeamUnsecure(2, "AlphaTuri");

            Console.WriteLine("\n\n\n\n\nUpdateParticipantTeamSecure");
            _repo.UpdateParticipantTeamSecure(3, "William");
        }

    }
}
