using System;
using System.Collections.Generic;

namespace MinimalFirst.Data.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
