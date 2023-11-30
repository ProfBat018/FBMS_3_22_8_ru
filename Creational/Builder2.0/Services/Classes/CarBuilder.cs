using Builder.Entities;
using Builder.Parts.Classes;
using Builder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Services.Classes;

class CarBuilder : ICarBuilder
{
    public Car CarToBuild { get; set; }    

    public CarBuilder()
    {
        CarToBuild = new Car();
    }

    public void SetEngine(string name, int volume)
    {
        CarToBuild.Parts.Add(new Engine()
        {
            Name = name,
            Volume = volume
        });
    }

    public void SetBody(string name, string color)
    {
        CarToBuild.Parts.Add(new Body()
        {
            Name = name,
            Color = color
        });
    }

    public void SetWheels(string name, int size)
    {
        CarToBuild.Parts.AddRange(new Wheel[]
        {
            new Wheel()
            {
                Name = name,
                Size = size
            },
            new Wheel()
            {
                Name = name,
                Size = size
            },
            new Wheel()
            {
                Name = name,
                Size = size
            },
            new Wheel()
            {
                Name = name,
                Size = size
            }
        });
    }
}
