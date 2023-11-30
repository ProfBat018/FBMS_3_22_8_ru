using Builder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Services.Interfaces;

interface ICarBuilder
{
    public Car CarToBuild { get; set; }
    public void SetEngine(string name, int volume);
    public void SetBody(string name, string color);
    public void SetWheels(string name, int size);
}
