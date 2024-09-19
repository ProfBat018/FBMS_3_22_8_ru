using System;
using System.Collections.Generic;

namespace ProductData.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public int? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();
    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
