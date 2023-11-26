ICharacterFactory characterFactory = new WarriorFactory();

Warrior w1 = characterFactory.CreateCharacter<Warrior>();

characterFactory = new MageFactory();

Mage m1 = characterFactory.CreateCharacter<Mage>();


interface ICharacterFactory
{
    public T CreateCharacter<T>() where T: ICharacter;
}


class WarriorFactory : ICharacterFactory
{
    public T CreateCharacter<T>() where T: ICharacter
    {
        Console.WriteLine("This is a warrior");
        var character = Activator.CreateInstance<T>();
        
        return character;
    }
}

class MageFactory : ICharacterFactory
{
    public T CreateCharacter<T>() where T : ICharacter
    {
        Console.WriteLine("This is a mage");

        var character = Activator.CreateInstance<T>();
        
        return character;
    }
}


class Warrior : ICharacter
{
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
}

class Mage : ICharacter
{
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
}

interface ICharacter
{
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
}

