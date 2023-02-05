namespace StarNextTestWebAPI.Models
{
    public class Flight
    {
        public string ID { get; set; }
        public IEnumerable<Segment> Segments { get; set; }
        public decimal AveragePrice { get; set; }
        public string CurrencySymbol { get; set; }

        // Methods

        // Copy data from derived class.
        public void Copy(FlightWithPassengers flightWithPassengers)
        {
            ID = flightWithPassengers.ID;
            Segments = flightWithPassengers.Segments;
            AveragePrice = flightWithPassengers.AveragePrice;
            CurrencySymbol = flightWithPassengers.CurrencySymbol;
        }

    }
}
