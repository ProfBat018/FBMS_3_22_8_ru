class VisaPayment : IPayment
{
    public void Pay(int amout)
    {
        Console.WriteLine($"Paying {amout} using Visa");
    }
}