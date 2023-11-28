using AbstractFactory.Entities.Classes;
using AbstractFactory.Entities.Interfaces;


namespace AbstractFactory.Fabrics.Classes;

class HumanFabric : ICharacterFabric
{

    public IEntity CreateCharacter(ICharacter character)
    {
        return new Human()
        {
            Character = character,
            HP = 100,
            MP = 100,
            ATK = 10,
            Defence = 10
        };
    }
}
