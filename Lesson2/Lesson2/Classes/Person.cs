namespace Classes.Lesson2;

class Person
{
    public string Name { get; }
    public int Age { get; set; }

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
