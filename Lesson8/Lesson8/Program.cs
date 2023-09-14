#region FirstExample

/*
MyList<int> list = new();

list.Add(1);
list.Add(2);
list.Add(3);

Console.WriteLine(list[0]);
Console.WriteLine(list[1]);

list[2] = 10;

class MyList<T>
{
    private List<T> _list = new();

    public void Add(T item)
    {
        _list.Add(item);
    }

    public T Get(int index)
    {
        return _list[index];
    }

    public int Count => _list.Count;

    public void Clear()
    {
        _list.Clear();
    }

    public void Remove(T item)
    {
        _list.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }

    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }
}
*/
#endregion

#region SecondExample

/*
using Lesson8;

Showroom<ITransport> showroom1 = new();

showroom1.Add(new Car());
showroom1.Add(new Scooter());

Showroom<Car> showroom2 = new();
Showroom<Scooter> showroom3 = new();

ITransport transport = new Car();


class Showroom<T> where T : ITransport
{
    private List<T> _list = new();

    public void Add(T item)
    {
        _list.Add(item);
    }
    public T Get(int index)
    {
        return _list[index];
    }
    public int Count => _list.Count;
    public void Clear()
    {
        _list.Clear();
    }
    public void Remove(T item)
    {
        _list.Remove(item);
    }
    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
    }
    public object this[int index]
    {
        get { return _list[index]; }
        set
        {
            if (value is T)
            {
                _list[index] = (T)value;
            }
        }
    }
}
*/

#endregion


// Func<int, bool> a =((int x) => x % 2 == 0);
// Predicate<int> predicate = new((int x) => x % 2 == 0);
//
// MyDelegate<int> myDelegate = new((int x) => x % 2 == 0);
//
// delegate bool MyDelegate<T>(T data);
