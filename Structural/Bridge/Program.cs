using Bridge.Model;
using Bridge.Services;
using System.Text;

var transportService = new TransportService();

ITransport transport = transportService.CreateTransport();

Console.WriteLine(transport);

var props = transport.TransportEntity.GetMetadata();

foreach (var prop in props)
{
    Console.WriteLine($"{prop.Name} {prop.PropertyType}");
}