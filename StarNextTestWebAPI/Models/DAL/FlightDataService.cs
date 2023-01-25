using System.Text.Json;

namespace StarNextTestWebAPI.Models.DAL
{
    public class FlightDataService
    {
        public List<Flight> GetFlights()
        {
            var flightsJson = File.ReadAllText("./FlightRawData/Raw_data RT - 2pax .json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<Flight>>(flightsJson, options);
        }
    }
}
