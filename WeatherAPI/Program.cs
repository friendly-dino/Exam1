// See https://aka.ms/new-console-template for more information
using WeatherAPI;
using WeatherAPI.Weather;

try
{
    Console.WriteLine("Deserialized JSON data: \n");
    await Weather.GetDetails(Constant.jsonResultURL + Constant.APIKey);
    Console.WriteLine("\nDeserialized XML data: \n");
    await Weather.GetDetails(Constant.xmlResultURL + Constant.APIKey);
}
catch (Exception ex)
{
    throw ex;
}
