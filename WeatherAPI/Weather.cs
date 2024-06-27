using System.Text.Json;
using static WeatherAPI.JsonResultModel;

namespace WeatherAPI
{
    public static class Weather
    {
        public static async Task GetJsonDetails(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Ensure a successful response
                if (response.IsSuccessStatusCode)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();

                    var deserialized = JsonSerializer.Deserialize<WeatherResponse>(jsonResult);

                    //this is sample print
                    Console.WriteLine($"Location: {deserialized.name}, {deserialized.sys.country}");
                    Console.WriteLine($"Temperature: {deserialized.main.temp}K");
                    Console.WriteLine($"Weather: {deserialized.weather[0].description}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching content from the URL: {ex.Message}");
            }



        }

    }
}
