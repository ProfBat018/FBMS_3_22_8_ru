
var s1 = MySingletonManager.GetInstance<MainViewModel>() as MainViewModel;

s1.Name = "Singleton 1";

Console.WriteLine(s1.Name);

var s2 = MySingletonManager.GetInstance<MainViewModel>() as MainViewModel;

Console.WriteLine(s2.Name);

Console.WriteLine("------------------");

s2.Name = "Singleton 2";

Console.WriteLine(s1.Name);
Console.WriteLine(s2.Name);


public static class MySingletonManager
{
    private static object? _instance;
    public static object GetInstance<T>()
    {
        if (_instance == null)
        {
            _instance = Activator.CreateInstance<T>();
        }
        return _instance;
    }
}

public class MainViewModel
{
    public string Name { get; set; }
}



