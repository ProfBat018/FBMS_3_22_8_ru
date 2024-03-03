using System.Diagnostics;
using System.Threading;

#region Lock

/*

class Program
{
    public static void Sample()
    {
        object lockObject = new();

        lock (lockObject)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }

    public static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread th1 = new(Sample);
            th1.Start();
            Thread.Sleep(10);
        }
    }
}

*/

#endregion

#region Mutex

/*
class Program
{
    public static void Sample()
    {
        Mutex mutex = new();

        mutex.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        mutex.ReleaseMutex();
    }

    public static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Thread th1 = new(Sample);
            th1.Start();
            Thread.Sleep(10);
        }
    }
}
*/

#endregion

#region Semaphore

/*
class Program
{
    public static void Sample()
    {
        Semaphore semaphore = new(2,2);

        semaphore.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"This is {i} from thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5);
        }

        semaphore.Release();
    }

    public static void Main(string[] args)
    {
        for (int i = 0; i < 6; i++)
        {
            Thread th1 = new(Sample);
            th1.Start();
            Thread.Sleep(10);
        }
    }
}

*/

#endregion

#region CountDownEvent

/*
class Program
{
    private static CountdownEvent countdownEvent = new(5);
    public static void Sample()
    {
        using Mutex mutex = new();
        mutex.WaitOne();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Hello from: {Thread.CurrentThread.ManagedThreadId}");
        }

        countdownEvent.Signal();
        mutex.ReleaseMutex();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Main started");

        for (int i = 0; i < 5; i++)
        {
            Thread th1 = new(Sample);
            th1.Start();
        }

        countdownEvent.Wait();

        Console.WriteLine("Main finished");
    }
}

*/

#endregion

#region ThreadPool
/*
class Program
{
    public static void Sample()
    {
        using Mutex mutex = new();

        mutex.WaitOne();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{i} from thread: {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.IsThreadPoolThread}");
        }
        mutex.ReleaseMutex();
        
    }

    public static void Main(string[] args)
    {
        CountdownEvent countdownEvent = new(5);

        Console.WriteLine("Main started");
        
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Sample();
                countdownEvent.Signal();
            });
        }
        countdownEvent.Wait();

        Console.WriteLine("Main finished");
    }
}
*/
#endregion



