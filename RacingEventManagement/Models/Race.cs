namespace RacingEventManagement.Models
{
    public class Race
    {
        public int RaceId { get; set; }
        public string Name { get; set; } // "Monaco Grand Prix"
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Distance { get; set; } // distance in kilometers
    }

}
