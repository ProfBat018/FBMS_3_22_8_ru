using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes.Characters;

class Warrior : IWarrior
{
    public int Rage { get; set; }

    public void SwordAttack()
    {
        Console.WriteLine("Sword attack");
    }
}
