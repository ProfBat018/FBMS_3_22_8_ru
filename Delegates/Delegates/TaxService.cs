namespace Delegates;

public class TaxService
{
    private List<Tax> TaxList = new();
    
    public void AddTax(Tax tax)
    {
        TaxList.Add(tax);
    }
    
    public decimal CalculateTax(decimal salary)
    {
        decimal totalTax = 0;
        foreach (Tax tax in TaxList)
        {
            totalTax += tax.TaxDelegate(salary);
        }
        return totalTax;
    }
}
