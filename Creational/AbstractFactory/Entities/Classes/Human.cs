using AbstractFactory.Entities.Interfaces;

namespace AbstractFactory.Entities.Classes;

class Human : IEntity
{
    public int HP { get; set; }
    public int MP { get; set; }
    public int ATK { get; set; }
    public int Defence { get; set; }
    public ICharacter Character { get; set; }
}
