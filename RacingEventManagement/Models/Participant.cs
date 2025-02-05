namespace RacingEventManagement.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Team { get; set; } // Red Bull Racing, Mercedes
        public int ExperienceYears { get; set; }
    }
}
