namespace StarNextTestWebAPI.Models
{
    public class Segment
    {
        public IEnumerable<Leg> Legs { get; set; }
        public decimal SegmentDuration { get; set; }
        public string ValidatingCarrier { get; set; }
    }
}
