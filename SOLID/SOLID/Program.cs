#region Part1

// Transport a = new Scooter();

// Transport a = new Suv();
//
// Suv b = new Suv();
//
// b.foo();

//
// TransportManager manager = new();
//
// var t1 = manager.CreateTransport();
//
//
// class TransportManager
// {
//     public Transport Type { get; set; }
//     public Transport CreateTransport()
//     {
//         return new Suv();
//     }
// }
// class Car : Transport
// {
//   
// }
//
// class Scooter : Transport
// {
// }
//
// class Suv : Car
// {
//     
// }
//
// class Transport
// {
//     public void foo()
//     {
//         Console.WriteLine("Hello, World!");
//     }
// }

#endregion


using SOLID;

WeatherService<WeatherForecastOpen> service = new();

try
{
    var res = service.GetWeatherByCity("Baku");
    Console.WriteLine(res.main.temp);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


