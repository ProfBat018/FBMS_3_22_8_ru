using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bridge.Model;

namespace Bridge.Services;

class TransportService
{
    public ITransport CreateTransport()
    {
        TransportType type = new();

        int selection;
        var transportTypes = type.GetType().GetEnumNames();

        Console.WriteLine("Enter transport type:\n");

        for (int i = 0; i < transportTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {transportTypes[i]}");
        }

        bool numberCheck = Int32.TryParse(Console.ReadLine(), out selection);

        if (numberCheck)
        {
            var transportType = GetTransportType((TransportType)selection);
            return GetTransport(transportType);
        }
        throw new ArgumentException("Selection is wrong");
    }

    public Type GetTransportType(TransportType userSelection) => userSelection switch
    {
        TransportType.Cargo => typeof(Cargo),
        TransportType.Passenger => typeof(Passenger),
        _ => throw new ArgumentException("Selection is wrong"),
    };

    public ITransport GetTransport(Type transportType)
    {
        var assembly = Assembly.GetExecutingAssembly(); // Рефлексия 

        List<Type> types = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ITransport))).ToList();

        int i = 1;

        foreach (var type in types)
        {
            Console.WriteLine($"{i}. {type.Name}");
            i++;
        }

        Console.WriteLine("Enter transport Name:\n");

        int selection = Int32.Parse(Console.ReadLine());

        var transport = Activator.CreateInstance(types[selection - 1]) as ITransport;

        IEntity entity = transport as IEntity;

        Console.WriteLine("Enter make:");
        transport.Make = Console.ReadLine();

        Console.WriteLine("Enter model:");
        transport.Model = Console.ReadLine();

        transport.TransportEntity = Activator.CreateInstance(transportType) as IEntity;

        return transport;
    }
}
