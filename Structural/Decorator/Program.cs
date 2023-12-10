BitcoinPayment bitcoinPayment = new();
MasterCardPayment masterCardPayment = new();
VisaPayment visaPayment = new();


// Decorator

PaymentDecoratorWithTwoCards paymentDecoratorWithTwoCards = new(new List<IPayment> () {bitcoinPayment, masterCardPayment, visaPayment});
//paymentDecoratorWithTwoCards.Pay(100);


PaymentDecoratorWithTax paymentDecoratorWithTax = new(bitcoinPayment);

paymentDecoratorWithTax.Pay(100);

