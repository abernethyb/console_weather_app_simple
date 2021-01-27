using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace consoleWeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Key key = new Key();

            Console.WriteLine("Get a current weather update by U.S. postal code");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("enter a valid U.S. zip code: ");
            string sZip = Console.ReadLine();
            //float lat = float.Parse(slat);
            // float lon = float.Parse(slon);
            // Console.WriteLine(lat);
            // Console.WriteLine(lon);
            //api.openweathermap.org/data/2.5/weather?zip=42240,us
            var uri = $"https://api.openweathermap.org/data/2.5/weather?zip={sZip},us&units=imperial&appid={key.name}";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStreamAsync();
                var weatherData = await JsonSerializer.DeserializeAsync<WeatherResponse>(json);

                Console.WriteLine($"Current weather in: {weatherData.placeName}");
                Console.WriteLine("");
                Console.WriteLine("Current Conditions:");
                Console.WriteLine("");
                Console.WriteLine($"Current temperature: {weatherData.current.temp} degrees F");
                foreach (Weather weather in weatherData.WeatherResponses)
                {
                    Console.WriteLine($"{weather.main}");
                    Console.WriteLine($"description: {weather.description}");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine("Try that zip code one more time");
            }
        }
    }
}