using Builder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Parts.Classes;

class Wheel : IPart
{
    public string Name { get; set; }
    public int Size { get; set; }
}
