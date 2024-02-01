namespace FluentApi.Data.Models;

public class Category
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }

    // В базе данных не сущетсвует, но он нужен для fluentApi
    // чтобы настроить связь между таблицами
    public ICollection<Product> Products { get; set; }
}