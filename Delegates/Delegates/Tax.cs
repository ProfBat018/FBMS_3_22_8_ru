namespace Delegates;

public class Tax
{
    public string Name { get; set; }
    public decimal Rate { get; set; }
    public Func<decimal, decimal> TaxDelegate { get; set; }
}