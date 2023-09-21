using Events;

var salaryService = new SalaryService(3000);

void tax1(decimal salary, ref decimal total)
{
    total += salary * 0.15m;
}

void tax2(decimal salary, ref decimal total)
{
    total += salary * 0.10m;
}

salaryService.TaxService.AddTax(tax1);
salaryService.TaxService.AddTax(tax2);


Console.WriteLine($"Netto Salary = {salaryService.Salary:C}");

