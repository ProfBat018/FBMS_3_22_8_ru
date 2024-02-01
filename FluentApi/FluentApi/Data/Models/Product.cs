namespace FluentApi.Data.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public float Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}