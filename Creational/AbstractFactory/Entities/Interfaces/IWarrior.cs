using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Interfaces;

interface IWarrior : ICharacter
{
    public int Rage { get; set; }
    public void SwordAttack();
}
