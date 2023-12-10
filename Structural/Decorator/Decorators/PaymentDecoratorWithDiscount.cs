class PaymentDecoratorWithDiscount : PaymentDecorator
{
    public PaymentDecoratorWithDiscount(IPayment payment) : base(payment)
    {
    }

    public override void Pay(int amout)
    {
        Console.WriteLine($"Paying {amout * 0.9} using discount");
    }
}