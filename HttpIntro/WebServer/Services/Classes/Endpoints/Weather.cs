namespace WebServer.Services.Classes.Endpoints;

public class Weather : IEndpoint
{
    public List<Forecast> GetWeatherForecast()
    {
        return new List<Forecast>()
        {
                new("Baku", 7.0f),
                new("Moscow", 5.0f),
                new("Berlin", 9.0f)
        };
    }
}

public record Forecast(string city, float temp);