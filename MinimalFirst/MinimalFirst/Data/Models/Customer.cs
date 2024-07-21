using System;
using System.Collections.Generic;

namespace MinimalFirst.Data.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
