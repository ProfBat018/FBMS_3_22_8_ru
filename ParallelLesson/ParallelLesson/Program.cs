using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

#region ParallelFor
/*
public class Example
{
    public static void Main(string[] args)
    {
        long totalSize = 0;

        var path = Directory.GetCurrentDirectory();
        
        String[] files = Directory.GetFiles(path);
       
        Parallel.For(0, files.Length,
            index => { 
                FileInfo fi = new FileInfo(files[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            } );
        
        Console.WriteLine($"Directory: {path}");
        Console.WriteLine("{0:N0} files, {1:N0} bytes", files.Length, totalSize);
    }
}
*/
#endregion

#region ParallelForeach

// List<int> nums = new() { 5, 4, 3, 2, 1 };
// Parallel.ForEach(nums, i =>
// {
//     Console.WriteLine($"{i} from {Thread.CurrentThread.ManagedThreadId} {Thread.CurrentThread.IsThreadPoolThread}");
// });

#endregion


