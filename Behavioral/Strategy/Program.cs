using System;

var paymentProcessor = new PaymentProcessor(new CreditCardPayment("1234-5678-9012-3456", "12/25"));

paymentProcessor.ProcessPayment(100.50f);

paymentProcessor.ChangePaymentStrategy(new PayPalPayment("user@example.com"));
paymentProcessor.ProcessPayment(50.25f);

paymentProcessor.ChangePaymentStrategy(new BankTransferPayment("123-456-789"));
paymentProcessor.ProcessPayment(75.75f);




