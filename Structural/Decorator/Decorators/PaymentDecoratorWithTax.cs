class PaymentDecoratorWithTax : PaymentDecorator
{
    public PaymentDecoratorWithTax(IPayment payment) : base(payment)
    {
    }

    public override void Pay(int amout)
    {
        Console.WriteLine($"Paying {amout * 1.1} using tax");
    }
}