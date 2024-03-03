#region OneTask
/*
using System.Runtime.CompilerServices;

void Sample()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"This is {i} from " +
                          $"thread: {Thread.CurrentThread.ManagedThreadId}" +
                          $"\nIsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    }
}

Console.WriteLine("Start of main");


Task task1 = Task.Factory.StartNew(Sample);

TaskAwaiter awaiter = task1.GetAwaiter();
awaiter.GetResult();

Console.WriteLine("End of Main");
*/
#endregion

#region MultipleTasks
/*
void Sample()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"This is {i} from " +
                          $"thread: {Thread.CurrentThread.ManagedThreadId}" +
                          $"\nIsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    }
}

Console.WriteLine("Start of main");

Task[] tasks = new Task[3];

for (int i = 0; i < tasks.Length; i++)
{
    tasks[i] = Task.Factory.StartNew(Sample);
    tasks[i].GetAwaiter().GetResult();
}

Console.WriteLine("End of Main");
*/
#endregion

#region MultipleTasksWithoutQueue

void Sample()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"This is {i} from " +
                          $"thread: {Thread.CurrentThread.ManagedThreadId}" +
                          $"\nIsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread}");
    }
}

Console.WriteLine("Start of main");

Task[] tasks = new Task[3];

for (int i = 0; i < tasks.Length; i++)
{
    tasks[i] = Task.Run(Sample);
}

Task.WaitAll(tasks);


Console.WriteLine("End of Main");

#endregion

