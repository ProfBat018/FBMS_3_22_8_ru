using Builder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Parts.Classes;

class Engine : IPart
{
    public string Name { get; set; }
    public int Volume { get; set; }
}
