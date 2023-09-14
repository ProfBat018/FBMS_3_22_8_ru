using System.Net;
using System.Text.Json;
using WeatherApp;

class WeatherDataService
{
    private readonly string _link = "https://api.openweathermap.org/data/2.5/weather?q=";
    private readonly string _key = "2b1fd2d7f77ccf1b7de9b441571b39b8";

    public WeatherData GetWeatherByCity(string cityName)
    {
        string url = $"{_link}{cityName}&appid={_key}&units=metric";
        using WebClient client = new();

        string? json = client.DownloadString(url);

        try
        {
            return JsonSerializer.Deserialize<WeatherData>(json) ?? throw new NullReferenceException("Error");
        }
        catch (Exception e)
        {
            throw;
        }   
    }
}