using System.Text.Json;
using System.Xml.Serialization;
using static WeatherAPI.Models.JsonResultModel;
using static WeatherAPI.Models.XmlResultModel;

namespace WeatherAPI.Weather
{
    public class DisplayWeatherData
    {
        protected static void PrintXmlResult(string result)
        {
            Current weatherResponse = DeserializeXml(result);
            //sample fields to be displayed
            Console.WriteLine($"Location: {weatherResponse.City.Name}, {weatherResponse.City.Country}");
            Console.WriteLine($"Temperature: {weatherResponse.Temperature.Value} {weatherResponse.Temperature.Unit}");
            Console.WriteLine($"Weather: {weatherResponse.Weather.Value}");
        }
        protected static void PrintJsonResult(string result)
        {
            WeatherResponse? deserialized = DeserializeJson(result);
            //sample fields to be displayed
            Console.WriteLine($"Location: {deserialized.name}, {deserialized.sys.country}");
            Console.WriteLine($"Temperature: {deserialized.main.temp}K");
            Console.WriteLine($"Weather: {deserialized.weather[0].description}");
            Console.WriteLine($"Sunrise: {deserialized.sys.sunrise}");
        }
        private static WeatherResponse? DeserializeJson(string jsonResult)
        {
            return JsonSerializer.Deserialize<WeatherResponse>(jsonResult);
        }
        private static Current DeserializeXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Current));
            using StringReader reader = new StringReader(xml);
            return (Current)serializer.Deserialize(reader);
        }
        #region experimental
        //possible use of loop to iterate fields
        //foreach (var weatherResponse in deserialized.weather)
        //{
        //    Type type = weatherResponse.GetType();
        //    foreach (PropertyInfo property in type.GetProperties())
        //    {
        //        object value = property.GetValue(weatherResponse);
        //        Console.WriteLine($"{property.Name}: {value}");
        //    }
        //    Console.WriteLine();
        //}
        #endregion
    }
}
