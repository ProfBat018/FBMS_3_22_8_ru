using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

// class Car
// {
//     public string Make { get; private set; }
//     public string Model { get; private set; }
//
//     public Car(string make, string model)
//     {
//         Make = make;
//         Model = model;
//     }
// }

// object data = "Elvin";
// string name = data as string;

/*
var foo = (int x, int y = 1) => x + y;


[Experimental("This is experimental Car class")]
class Car(string make, string model)
{
    public string Make { get; set; } = make;
    public string Model { get; private set; } = model;
}

*/



Console.WriteLine(A.kenan);

class A
{
    public static string name = "Elvin";
    public static string kenan;

    static A()
    {
        Foo();
        if (name == "Elvin")
        {
            kenan = "Kenan";
        }
    }
    
    public static void Foo()
    {
        Console.WriteLine("Foo");
    }
}

