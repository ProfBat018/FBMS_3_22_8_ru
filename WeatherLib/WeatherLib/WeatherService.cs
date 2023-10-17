using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLib;

public class WeatherService
{
    public static Forecast GetWeatherByCity(string cityName)
    {
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=2b1fd2d7f77ccf1b7de9b441571b39b8&units=metric";

        try
        {
            string json = DownloadService.Download(url);
            var res = DeserializeService.Deserialize<Forecast>(json);

            return res;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
