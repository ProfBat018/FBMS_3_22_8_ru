using System;
using System.Collections.Generic;

namespace ProductData.Models;


public partial class AttributeValue
{
    public int AttributeValueId { get; set; }

    public int AttributeId { get; set; }

    public string Value { get; set; } = null!;

    public virtual ProductAttribute Attribute { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
