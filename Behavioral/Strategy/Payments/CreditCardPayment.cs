public class CreditCardPayment : IPaymentStrategy
{
    private string cardNumber;
    private string expirationDate;

    public CreditCardPayment(string cardNumber, string expirationDate)
    {
        this.cardNumber = cardNumber;
        this.expirationDate = expirationDate;
    }

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Обработка кредитной картой. Сумма: {amount:C}, Карта: {cardNumber}, Срок действия: {expirationDate}");
    }
}