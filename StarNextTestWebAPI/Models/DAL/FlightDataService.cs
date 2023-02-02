using System.Text.Json;

namespace StarNextTestWebAPI.Models.DAL
{
    public class FlightDataService
    {
        public List<Flight> GetFlights()
        {
            //var flightsJson = File.ReadAllText("./FlightRawData/Raw_data RT - 2pax .json");
            var flightsJson = File.ReadAllText("./FlightRawData/Raw_data RT - 2pax .json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, Converters = { new FlightConverter() } };
            //var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            //return JsonSerializer.Deserialize<List<Flight>>(flightsJson, options);
            return JsonSerializer.Deserialize<List<Flight>>(flightsJson, options);
            //return flights.Where(f => f != null).ToList();
        }
    }
}
