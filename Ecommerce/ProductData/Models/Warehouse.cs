using System;
using System.Collections.Generic;

namespace ProductData.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public int ProductId { get; set; }

    public int StockQuantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Product Product { get; set; } = null!;
}
