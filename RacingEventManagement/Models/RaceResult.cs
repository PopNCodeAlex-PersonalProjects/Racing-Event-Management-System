namespace RacingEventManagement.Models
{
    public class RaceResult
    {
        public int RaceResultId { get; set; }
        public double FinishTime { get; set; }
        public int Position { get; set; }
        public int RaceId { get; set; }
        public int ParticipantId { get; set; }
    }
}
