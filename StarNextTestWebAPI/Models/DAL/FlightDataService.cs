using System.Text.Json;

namespace StarNextTestWebAPI.Models.DAL
{
    public class FlightDataService
    {
        // Reads JSON file and returns a formatted by scheme list of the flights' content.
        public List<Flight> GetFlights()
        {
            var flightsJson = File.ReadAllText("./FlightRawData/Raw_data RT - 2pax .json");
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<Flight>>(flightsJson, options);
        }

        // Returns list of all flights where there are <2 passengers.
        public List<Flight> GetFlightsPassengerFiltered()
        {
            var flightsJson = File.ReadAllText("./FlightRawData/Raw_data RT - 2pax .json");
            var flightsWithPassengersSerialized = JsonSerializer.Deserialize<List<FlightWithPassengers>>(flightsJson);
            List<FlightWithPassengers> flightsWithPassengers = flightsWithPassengersSerialized.Where(flight => flight.Passengers.Count() < 2).ToList();
            List<Flight> flights = new();
            foreach (var flightWithPassenger in flightsWithPassengers)
            {
                Flight flight = new();
                flight.Copy(flightWithPassenger);
                flights.Add(flight);
            }
            return flights;
        }
    }

}
