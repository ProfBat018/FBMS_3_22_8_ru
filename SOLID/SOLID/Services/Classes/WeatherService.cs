using SOLID.Models.Classes;
using SOLID.Models.Interfaces;


namespace SOLID.Services.Classes;

public class WeatherService<T> where T : IWeather
{
    private readonly ApiService _apiService = new();
    private readonly DeserializeService<T> _deserializeService = new();
    private Dictionary<string, EntityApiPath> _entityApiPaths = new();

    public WeatherService()
    {
        _entityApiPaths.Add("open",
            new EntityApiPath("https://api.openweathermap.org/data/2.5/weather?q=",
                "2b1fd2d7f77ccf1b7de9b441571b39b8"));
        _entityApiPaths.Add("binq",
            new EntityApiPath("https://api.bing.microsoft.com/v7.0/weather/forecast?q=",
                "b1b15e88fa797225412429c1c50c122a1"));
    }

    public T GetWeatherByCity(string cityName)
    {
        // try
        // {
        //     if (typeof(T) is WeatherForecastOpen)
        //     {
        //         string url =
        //             $"{_entityApiPaths["open"].Link}{cityName}&appid={_entityApiPaths["open"].Key}&units=metric";
        //     }
        //     else if (typeof(T) is WeatherForecastBinq)
        //     {
        //         string url =
        //             $"{_entityApiPaths["binq"].Link}&city={cityName}&key={_entityApiPaths["binq"].Key}";
        //     }
        //     else
        //     {
        //         throw new Exception("Unknown type");
        //     }
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     throw;
        // }
        
        var type = typeof(T);
        
        // switch expression
        string url = type switch
        {
            not null when type == typeof(WeatherForecastOpen) =>
                $"{_entityApiPaths["open"].Link}{cityName}&appid={_entityApiPaths["open"].Key}&units=metric",
            not null when type == typeof(WeatherForecastBinq) =>
                $"{_entityApiPaths["binq"].Link}&city={cityName}&key={_entityApiPaths["binq"].Key}",
            _ => throw new Exception("Unknown type")
        };

        try
        {
            string json = _apiService.GetData(url);
            return _deserializeService.Deserialize(json);
        }
        catch (Exception e)
        {
            throw;
        }        
    }
}