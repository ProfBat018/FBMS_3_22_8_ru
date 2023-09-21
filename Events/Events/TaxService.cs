namespace Events;

class TaxService
{
    public TaxDelegate<decimal>? Taxes { get; set; }
    public void AddTax(TaxDelegate<decimal> tax)
    {
        Taxes += tax;
    }
    
    public decimal CalculateTaxes(decimal salary)
    {
        decimal totalTax = 0;
        Taxes?.Invoke(salary, ref totalTax);
        return totalTax;
    }
}

