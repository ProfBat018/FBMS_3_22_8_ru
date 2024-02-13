namespace Inheritance;

class Bicycle : Transport
{
    public int WheelDiameter {get; set;}
    public string FrameMaterial {get; set;}
    public TransportType TransportType { get; set; } = TransportType.Bicycle;
}

