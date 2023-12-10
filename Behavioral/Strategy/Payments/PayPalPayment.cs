public class PayPalPayment : IPaymentStrategy
{
    private string email;

    public PayPalPayment(string email)
    {
        this.email = email;
    }

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Обработка через PayPal. Сумма: {amount:C}, Email: {email}");
    }
}