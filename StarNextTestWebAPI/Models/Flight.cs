namespace StarNextTestWebAPI.Models
{
    public class Flight
    {
        public string ID { get; set; }
        public IEnumerable<Segment> Segments { get; set; }
        public decimal AveragePrice { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
