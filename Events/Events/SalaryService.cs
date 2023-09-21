namespace Events;

class SalaryService
{
    private decimal _totalTax;
    private decimal _salary;
    public decimal Salary
    {
        get
        {
            _totalTax = TaxService.CalculateTaxes(_salary);
            _salary -= _totalTax;
            Console.WriteLine($"Total tax = {_totalTax:C}");
            return _salary;
        }
        set => _salary = value;
    }

    public TaxService TaxService { get; set; }

    public SalaryService(decimal salary)
    {
        Salary = salary;
        TaxService = new();
    }    
}