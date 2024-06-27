namespace WeatherAPI.Weather
{
    public class Weather : DisplayWeatherData
    {
        public static async Task GetDetails(string url)
        {
            using var httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                // Ensure a successful response
                if (response.IsSuccessStatusCode)
                {
                    string contentType = response.Content.Headers.ContentType.MediaType;
                    string result = await response.Content.ReadAsStringAsync();
                    switch (contentType)
                    {
                        case "application/json":
                            PrintJsonResult(result);
                            break;
                        case "application/xml":
                            PrintXmlResult(result);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
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
