using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bridge.Model;

namespace Bridge.Services;
class TransportService
{
    public ITransport CreateTransport<T>() where T: IEntity
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

        Type transportType = numberCheck ? GetTransportType((TransportType)selection) : throw new Exception();

        var transport = Activator.CreateInstance<T>();


    }

    public Type GetTransportType(TransportType userSelection) => userSelection switch
    {
        TransportType.Cargo => typeof(ICargo),
        TransportType.Passenger => typeof(IPassenger),
        _ => throw new ArgumentException("Selection is wrong"),
    };
}
