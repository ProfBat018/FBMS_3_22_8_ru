using MongoDB.Entities;

namespace Mapping;

public class Engine : Entity
{
    public string Name { get; set; }
    public int Power { get; set; }
    public int Volume { get; set; }
}