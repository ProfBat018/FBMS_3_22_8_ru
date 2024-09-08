using System;
using System.Collections.Generic;

namespace ProductData.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus Status { get; set; } = null!;
}
