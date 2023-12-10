public class BankTransferPayment : IPaymentStrategy
{
    private string accountNumber;

    public BankTransferPayment(string accountNumber)
    {
        this.accountNumber = accountNumber;
    }

    public void ProcessPayment(float amount)
    {
        Console.WriteLine($"Банковский перевод. Сумма: {amount:C}, Номер счета: {accountNumber}");
    }
}