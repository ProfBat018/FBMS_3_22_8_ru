#region ElnurunSuali

// int[] numbers = new int[5];

// numbers[0] = 1;
// numbers[1] = 0;
// numbers[2] = 3;

// foreach (var num in numbers)
// {
    // Console.WriteLine(num);
// }

// List<int> nums = new();
//
// nums.Add(1);
// nums.Add(0);
// nums.Add(3);
//
// Console.WriteLine(nums.Count);

#endregion

#region TypeAndReflection

using System.Reflection;
using System.Threading.Channels;

// Person p1 = new("Elvin", 21);

// Type t = typeof(Person);

// ConstructorInfo[] ctors = t.GetConstructors();
// MethodInfo[] methods = t.GetMethods();

// var method = t.GetMethod("set_Age");

// method.Invoke(p1, new object[] { 22 });

// Console.WriteLine(p1);

// foreach (var ctor in ctors)
// {
//     Console.WriteLine(ctor);
// }

// foreach (MethodInfo method in methods)
// {
//     Console.WriteLine(method.Name);
//     if (method.Name == "ToString")
//     {
//         Console.WriteLine(method.Invoke(p1, null));
//         
//         // Console.WriteLine(p1.ToString());
//     }
// }


#endregion

#region Exceptions
/*
try
{
    Person p1 = new("Elvin", 151);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

class AgeException : Exception
{
    public int Code { get; private set; }
    
    public AgeException(string message) : base(message)
    {
    }
    
    public AgeException(string message, int code) : base(message)
    {
        Code = code;
    }

    public override string ToString()
    {
        return $"Message: {Message}\nCode: {Code}";
    }
}
*/
#endregion

#region Indexers

MyArray arr = new(5);

arr.Add(1);
arr.Add(2);
arr.Add(3);
arr.Add(4);
arr.Add(5);

Console.WriteLine(arr[1]);
class MyArray
{
    public List<MyInt> Nums { get; set; }
    public int Size { get; private set; }
    
    public MyArray(int size)
    {
        Nums = new List<MyInt>(size);
    }

    public void Add(int num)
    {
        Nums.Add(new MyInt(num));
    }

    public MyInt this[int index]
    {
        get
        {
            return Nums[index];
        }
        set
        {
            Nums[index] = value;
        }
    }
}

class MyInt {
    public int Value { get; init; }

    public MyInt()
    {
        
    }
    public MyInt(int value)
    {
        Value = value;
    }
}



#endregion
