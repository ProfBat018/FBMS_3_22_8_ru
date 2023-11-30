using Builder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Entities;

class Car
{
    public List<IPart> Parts { get; set; }

    public Car()
    {
        Parts = new List<IPart>();
    }

    public void AddPart(IPart part)
    {
        Parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("Car parts:");
        foreach (var part in Parts)
        {
            Console.WriteLine($"Part name: {part.Name}");
        }
    }
}
