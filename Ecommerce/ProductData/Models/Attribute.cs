using System;
using System.Collections.Generic;

namespace ProductData.Models;

public partial class ProductAttribute
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
}
