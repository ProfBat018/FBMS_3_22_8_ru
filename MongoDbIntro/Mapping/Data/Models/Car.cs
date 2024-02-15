using MongoDB.Entities;

namespace Mapping;

public class Car : Entity
{
    public string Make { get; set; }
    public string Model { get; set; }
    public DateTime ProductionDate { get; set; }
    public Engine EngineType { get; set; }
}