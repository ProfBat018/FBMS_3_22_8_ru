namespace WebServer.Services.Classes.Endpoints;

public class Car : IEndpoint
{
    public List<Automobile> GetCarsData()
    {
        return new()
        {
            new("Mercedes", "C200"),
            new("BMW", "528i"),
            new("KIA", "Sorento")
        };
    }
}

public record Automobile(string make, string model);