namespace StarNextTestWebAPI.Models
{
    public class Passenger
    {
        public decimal FareBase { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalTax { get; set; }
        public int PaxType { get; set; }
        public object BaggageUpgrade { get; set; }
    }
}
