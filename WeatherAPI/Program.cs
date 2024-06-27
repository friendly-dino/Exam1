// See https://aka.ms/new-console-template for more information


using WeatherAPI;

try
{

    await Weather.GetJsonDetails(Constant.jsonResultURL + Constant.APIKey);

}
catch (Exception)
{

    throw;
}
