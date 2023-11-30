using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model;

interface ITransport
{
    public string Make { get; set; }
    public string Model { get; set; }
}