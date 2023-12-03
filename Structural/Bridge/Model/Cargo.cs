using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model;

class Cargo : IEntity
{
    public float MaxWeight { get; set; }
}