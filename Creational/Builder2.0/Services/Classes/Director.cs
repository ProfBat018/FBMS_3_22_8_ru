using Builder.Entities;
using Builder.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Services.Classes;

class Director
{
    private readonly ICarBuilder builder;

    public Director(ICarBuilder builder)
    {
        this.builder = builder;
    }

    public Car BuildBaseCar()
    {
        builder.SetEngine("V8", 5);
        builder.SetBody("Sedan", "Black");
        builder.SetWheels("Sport", 18);


        return builder.CarToBuild;
    }

    public Car BuildCarWithSportEngine()
    {
        builder.SetEngine("V8", 5);
        builder.SetBody("Sedan", "Black");
        builder.SetWheels("Sport", 18);

        return builder.CarToBuild;
    }
}
