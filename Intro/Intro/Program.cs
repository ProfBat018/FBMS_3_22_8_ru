#region Part1

/*
ThreadStart action = new(() =>
{
        Console.WriteLine("El hilo ha comenzado");
});

ThreadStart action2 = new(() =>
{
        Console.WriteLine("El hilo ha comenzado 2");
});

ParameterizedThreadStart action3 = new((object obj) =>
{
        Console.WriteLine($"El hilo ha comenzado {obj}");
});

Thread th1 = new(action);
th1.Start();

th1 = new Thread(action2);
th1.Start();

th1 = new Thread(action3);
th1.Start(3);
*/

#endregion


#region Part2

class Program
{
    public static void Example()
    {
        Thread th1 = new(() =>
        {
            Console.WriteLine("Buenos días");
            Console.WriteLine($"This thread is created by me. Id is: {Thread.CurrentThread.ManagedThreadId}");
        });
        
        th1.Start();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main Thread Started");
        Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Example();
        Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Main Thread Ended");    
        
    }
}

#endregion