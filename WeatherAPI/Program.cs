// See https://aka.ms/new-console-template for more information
using WeatherAPI;

try
{
    Console.WriteLine("Deserialized JSON data: \n");
    await Weather.GetDetails(Constant.jsonResultURL + Constant.APIKey, ResultFormat.Json);
    Console.WriteLine("\nDeserialized XML data: \n");
    await Weather.GetDetails(Constant.xmlResultURL + Constant.APIKey, ResultFormat.Xml);
}
catch (Exception ex)
{
    throw ex;
}
