class Person
{
    private int _age;
    public string Name { get; }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
            {
                throw new AgeException("Age must be between 0 and 150", 1);
            }
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public static bool operator >(Person p1, Person p2)
    {
        return p1.Age > p2.Age;
    }

    public static bool operator <(Person p1, Person p2)
    {
        return p1.Age < p2.Age;
    }

    public override string ToString()
    {
        return $"{Name}\t{Age}";
    }
}