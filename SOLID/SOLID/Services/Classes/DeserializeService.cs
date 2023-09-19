using System.Text.Json;
using SOLID.Models.Interfaces;


namespace SOLID.Services.Classes;

public class DeserializeService<T> where T : IEntity
{
    public T Deserialize(string json)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(json) ?? throw new NullReferenceException("Error while deserializing");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
