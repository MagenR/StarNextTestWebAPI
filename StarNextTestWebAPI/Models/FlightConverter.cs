using System.Text.Json.Serialization;
using System.Text.Json;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

namespace StarNextTestWebAPI.Models
{
    public class FlightConverter : JsonConverter<List<Flight>>
    {
        public override List<Flight> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var list = new List<Flight>();
            int passengerCount = 0;
            bool KeepReadingArrayFlag = true;
            byte[] buffer = Encoding.UTF8.GetBytes(reader.GetString());
            var serializationReader = new Utf8JsonReader(buffer);

            while (reader.Read())
            {
                // Start of a new Flight object.
                if (reader.TokenType == JsonTokenType.StartObject)
                {
                    // Read until reached the passengers.
                    while (reader.TokenType != JsonTokenType.PropertyName && reader.GetString() != "Passengers")
                    {
                        reader.Read();
                    }

                    // Run over the array, and count the passengers.
                    while (reader.Read() && KeepReadingArrayFlag)
                    {
                        if (reader.TokenType == JsonTokenType.StartObject)
                        {
                            passengerCount++;
                        }

                        if (reader.TokenType == JsonTokenType.EndArray)
                        {
                            KeepReadingArrayFlag = false;
                        }
                    }

                    // Read until the last Property of the Flight object.
                    while (reader.TokenType != JsonTokenType.PropertyName && reader.GetString() != "DeepLinkRef")
                    {
                        reader.Read();
                    }

                    // Check if the passenger count is less than 2.
                    if (passengerCount < 2)
                    {
                        // Read the flight object.
                        var flight = JsonSerializer.Deserialize<Flight>(ref serializationReader, options); // WARNING: will push reader all the way to the end of the object!!!
                        // Add the flight to the list.
                        list.Add(flight);
                    }

                    // Re-Initialize the counter and flag.
                    KeepReadingArrayFlag = true;
                    passengerCount = 0;

                }
            }

            return list;
        }

        public override void Write(Utf8JsonWriter writer, List<Flight> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
