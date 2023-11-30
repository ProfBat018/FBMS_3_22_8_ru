using Builder.Parts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Parts.Classes;

class Body : IPart
{
    public string Name { get; set; }
    public string Color { get; set; }
}
