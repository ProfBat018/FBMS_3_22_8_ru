using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model;

class Passenger : IEntity
{
    public int MaxPassengerCount { get; set; }
}