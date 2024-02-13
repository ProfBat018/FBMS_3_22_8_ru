namespace Inheritance;

public class Car : Transport
{
    public int HorsePower {get; set;}
    public string EngineType {get; set;}
    public TransportType TransportType { get; set; } = TransportType.Car;
}