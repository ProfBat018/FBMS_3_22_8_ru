#region WithoutLock

/*
class Program
{
    public static void CountToFive()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Main started...");
        for (int i = 0; i < 5; i++)
        {
            Thread th = new(CountToFive);
            Console.WriteLine($"Created thread: {th.ManagedThreadId}");
            th.Start();
        }
    }
}
*/

#endregion

#region WithLock

/*
class Program
{
    public static void CountToFive()
    {
        object? locker = new();
        lock (locker)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main started...");
        for (int i = 0; i < 5; i++)
        {
            Thread th = new(CountToFive);
            Console.WriteLine($"Created thread");
            th.Start();
        }
    }
}

*/

#endregion

#region WithMutex

class Program
{
    public static void CountToFive()
    {
        // Первый параметр - начальное состояние, второй - имя
        // То есть, если первый параметер true, то он по умолчанию приналжежит текущему потоку
        // другой поток не сможет захватить его
        // Название для Mutex нужно, просто так )) 
        
        
        using Mutex mutex = new(false, "Mutex");
        mutex.WaitOne();
        
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
        }
        mutex.ReleaseMutex();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main started...");
        for (int i = 0; i < 5; i++)
        {
            Thread th = new(CountToFive);
            Console.WriteLine($"Created thread");
            th.Start();
        }
    }
}

#endregion