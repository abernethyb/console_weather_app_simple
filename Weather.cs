using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace consoleWeatherApp
{
    public class Weather
    {

        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }

    }
}