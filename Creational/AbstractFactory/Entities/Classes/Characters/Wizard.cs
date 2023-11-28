using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes.Characters;

class Wizard : IWizard
{
    public int Wisdom { get; set; }

    public void FireballAttack()
    {
        Console.WriteLine("Fireball Attack");
    }
}
