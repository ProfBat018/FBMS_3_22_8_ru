using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model
{
    class Plane : ITransport
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public IEntity TransportEntity { get; set; }
        override public string ToString()
        {
            return $"{Make} {Model} {TransportEntity.GetType().Name}";
        }
    }
}
