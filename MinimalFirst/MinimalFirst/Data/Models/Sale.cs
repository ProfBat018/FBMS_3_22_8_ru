using System;
using System.Collections.Generic;

namespace MinimalFirst.Data.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public int SalespersonId { get; set; }

    public DateOnly SaleDate { get; set; }

    public decimal SalePrice { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Salesperson Salesperson { get; set; } = null!;
}
