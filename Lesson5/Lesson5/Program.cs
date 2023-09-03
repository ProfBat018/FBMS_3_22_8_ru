#region Abstract

/*
Transport t1 = new();
Car c1 = new();


class Transport
{
    private string _make;
    public virtual string Make { get => "Make from Transoprt"; set => _make = value; }
}

class Car : Transport
{
    private string _make;
    public override string Make { get => "Make from Car"; set => _make = value; }
}

*/

/*
Transport t1 = new();
Car c1 = new();

abstract class Transport
{
    private string _make;
    public abstract string Make { get; set; }

    public virtual void foo()
    {
        Console.WriteLine("foo from Transport");
    }
}

class Car : Transport
{
    public override string Make { get; set; }
}
*/

#endregion


#region DefaultMethods

// В каждом классе есть 4 метода, которые можно переопределить
// ToString
// Equals
// GetHashCode
// GetType


object t1 = new Transport() { Make = "Ford", Model = "Focus", Year = 2010 };
object t2 = new Transport() { Make = "Ford", Model = "Focus", Year = 2010 };

Console.WriteLine(t1.Equals(t2));

Console.WriteLine(t1.GetHashCode());
Console.WriteLine(t2.GetHashCode());
Console.WriteLine(5.GetHashCode());

Dictionary<int, string> a = new();
a.Add(1, "one");
a.Add(2, "two");
a.Add(3, "three");
a.Add(1, "sdfsdf");

class Transport
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $"Make: {Make}, Model: {Model}, Year: {Year}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Transport) // obj.GetType() == typeof(Transport)
        {
            Transport t = obj as Transport;
            return t.Make == Make && t.Model == Model && t.Year == Year;
        }

        return false;
    }
}

#endregion