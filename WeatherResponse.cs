using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace consoleWeatherApp
{
    public class WeatherResponse
    {
        [JsonPropertyName("main")]
        public Current current { get; set; }

        [JsonPropertyName("name")]
        public string placeName { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> WeatherResponses { get; set; }

    }
}