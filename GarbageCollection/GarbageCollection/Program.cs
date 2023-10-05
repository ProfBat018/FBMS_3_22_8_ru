#region Part1 

/*

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace ConsoleApplication1
{
    class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("Constructor called");
        }

        [Required]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Password { get; set; }
        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        
        ~MyClass()
        {
            Thread.Sleep(2000);

            Console.WriteLine("Finalizer called");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start of Main");

            MyClass obj = new MyClass()
            {
                Name = "John",
                Surname = "Doe"
            };

            GC.Collect();
        }
    }


}

*/

#endregion

#region Part2

using System.Text;

StringBuilder name = new ("Elvin");

while(true)
{
    name.Append("1");
    Thread.Sleep(100);
}

#endregion

a b = new a()
{
    x = 3,
    y = 4
};


class a
{
    public int x { get; init; }
    public int y { get; init; }
    
    public a(){}
    
    public a(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void foo()
    {
        x = 5;
    }
}