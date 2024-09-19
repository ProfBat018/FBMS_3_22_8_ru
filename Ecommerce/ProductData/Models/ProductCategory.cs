namespace ProductData.Models;

public class ProductCategory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}
