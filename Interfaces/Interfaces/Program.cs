
// IDevice device = new Phone();
// device.TurnOn();

// Computer device = new();
// IDevice d = device;
// d.TurnOff();

void BuyDevice(IDevice d)
{
    
}


class Phone : IDevice
{
    public void Call()
    {
        
    }
    public void TurnOn()
    {
        Console.WriteLine("Phone is turning on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Phone is turning off");
    }
}


class Computer : IDevice
{
    public void Foo()
    {
        
    }

    public void TurnOn()
    {
        Console.WriteLine("Computer is turning on");
    }

    public void TurnOff()
    {
        Console.WriteLine("Computer is turning off");
    }
}

interface IDevice
{
    public void TurnOn();
    public void TurnOff();
}






