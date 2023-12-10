class MasterCardPayment : IPayment
{
    public void Pay(int amout)
    {
        Console.WriteLine($"Paying {amout} using MasterCard");
    }
}