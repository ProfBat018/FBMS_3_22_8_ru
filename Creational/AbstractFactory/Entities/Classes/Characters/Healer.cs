using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes.Characters;

class Healer : IHealer
{
    public int HealthReserve { get; set; }

    public void MassHeal()
    {
        Console.WriteLine("Mass Heal");
    }
}
