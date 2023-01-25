namespace StarNextTestWebAPI.Models
{
    public class Leg
    {
        public Point DeparturePoint { get; set; }
        public Point ArrivalPoint { get; set; }
        public string FlightNumber { get; set; }
        public string AirlineName { get; set; }
        public string AirlineCode { get; set; }
    }
}
