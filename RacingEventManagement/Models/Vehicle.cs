namespace RacingEventManagement.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; } //Ferrari, Porsche
        public string Model { get; set; } // 911 GT3, F8 Tributo
        public double Horsepower { get; set; } // Engine power
        public double TopSpeed { get; set; } // km/h
    }

}
