using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Entities.Classes;

class Elf : IEntity
{
    public int HP { get; set; }
    public int MP { get; set; }
    public int ATK { get; set; }
    public int Defence { get; set; }
    public ICharacter Character { get; set; }
}
