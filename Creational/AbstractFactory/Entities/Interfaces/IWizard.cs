using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Interfaces;

interface IWizard : ICharacter
{
    public int Wisdom { get; set; }
    public void FireballAttack();
}
