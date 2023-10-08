using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2.Model;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string ImagePhoto { get; set; }
    public DateTime ProductionDate { get; set; }

    override public string ToString()
    {
        return $"{Make} {Model} ({ProductionDate.Year})";
    }   
}
