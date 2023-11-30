using Bridge.Model;
using Bridge.Services;

var transportService = new TransportService();

ITransport transport = transportService.CreateTransport();

transport.Make = "Mercedes";
transport.Model = "CLS 250D";

Console.WriteLine(transport.Make);




