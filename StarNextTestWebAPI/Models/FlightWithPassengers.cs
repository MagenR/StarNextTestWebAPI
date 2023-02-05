namespace StarNextTestWebAPI.Models
{
    public class FlightWithPassengers : Flight
    {
        public IEnumerable<Passenger> Passengers { get; set; }
    }
}
