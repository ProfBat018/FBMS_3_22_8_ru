using System;
public class StateChangedEventArgs : EventArgs
{
    public string Message { get; }

    public StateChangedEventArgs(string message)
    {
        Message = message;
    }
}

public class SubjectWithEvent
{
    public event EventHandler<StateChangedEventArgs> StateChanged;

    public void DoSomethingImportant()
    {
        Console.WriteLine("Something important is happening.");
        OnStateChanged("State has been changed.");
    }

    protected virtual void OnStateChanged(string message)
    {
        StateChanged?.Invoke(this, new StateChangedEventArgs(message));
    }

    public void RemoveObserver(ObserverWithEvent observer)
    {
        StateChanged -= observer.HandleStateChanged;
        Console.WriteLine($"{observer.Name} has been unsubscribed.");
    }
}

public class ObserverWithEvent
{
    private string name;
    public string Name => name;

    public ObserverWithEvent(string name)
    {
        this.name = name;
    }

    public void HandleStateChanged(object sender, StateChangedEventArgs e)
    {
        Console.WriteLine($"{name} received message: {e.Message}");
    }

    public void Unsubscribe(SubjectWithEvent subject)
    {
        subject.RemoveObserver(this);
    }
}

class Program
{
    static void Main()
    {
        var observer1 = new ObserverWithEvent("Observer 1");
        var observer2 = new ObserverWithEvent("Observer 2");

        var subject = new SubjectWithEvent();

        subject.StateChanged += observer1.HandleStateChanged;
        subject.StateChanged += observer2.HandleStateChanged;

        subject.DoSomethingImportant();

        observer1.Unsubscribe(subject);

        subject.DoSomethingImportant();
    }
}
