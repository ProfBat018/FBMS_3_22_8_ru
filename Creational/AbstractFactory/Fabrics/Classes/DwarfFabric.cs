using AbstractFactory.Entities.Classes;
using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbstractFactory.Fabrics.Classes;

class DwarfFabric : ICharacterFabric
{
    public IEntity CreateCharacter(ICharacter character)
    {
        return new Dwarf()
        {
            Character = character,
            HP = 100,
            MP = 200,
            ATK = 10,
            Defence = 10
        };
    }
}
