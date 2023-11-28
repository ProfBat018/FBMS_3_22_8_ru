using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Interfaces;

interface IHealer : ICharacter
{
    public int HealthReserve { get; set; }
    public void MassHeal();
}
