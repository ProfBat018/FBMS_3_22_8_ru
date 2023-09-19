using System.Transactions;
using Delegates;

TaxService taxService = new();


Tax tax1 = new()
{
    Name = "Federal Tax",
    Rate = 0.15m,
    TaxDelegate = (salary) => salary * 0.15m
};

Tax tax2 = new()
{
    Name = "Provincial Tax",
    Rate = 0.10m,
    TaxDelegate = (salary) => salary * 0.10m
};

taxService.AddTax(tax1);
taxService.AddTax(tax2);


Console.WriteLine("Enter your salary:");
decimal salary = Decimal.Parse(Console.ReadLine());

decimal totalTax = taxService.CalculateTax(salary);

Console.WriteLine($"Total tax: {totalTax:C}");
Console.WriteLine($"Netto salary: {salary - totalTax:C}");



