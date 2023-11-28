using AbstractFactory.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Fabrics;

interface ICharacterFabric
{
    public IEntity CreateCharacter(ICharacter character);
}


