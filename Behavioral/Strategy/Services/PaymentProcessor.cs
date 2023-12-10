public class PaymentProcessor
{
    private IPaymentStrategy paymentStrategy;

    public PaymentProcessor(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }
    
    public void ProcessPayment(float amount)
    {
        paymentStrategy.ProcessPayment(amount);
    }

    public void ChangePaymentStrategy(IPaymentStrategy newPaymentStrategy)
    {
        paymentStrategy = newPaymentStrategy;
    }
}