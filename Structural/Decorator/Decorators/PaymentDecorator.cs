class PaymentDecorator 
{
    private IPayment _payment;

    public PaymentDecorator()
    {
        
    }
    public PaymentDecorator(IPayment payment)
    {
        _payment = payment;
    }

    public virtual void Pay(int amout)
    {
        _payment.Pay(amout);
    }
}