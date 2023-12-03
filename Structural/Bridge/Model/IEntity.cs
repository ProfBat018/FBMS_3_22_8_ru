using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Model;
interface IEntity
{
    public PropertyInfo[] GetMetadata()
    {
        return this.GetType().GetProperties();
    }
}
