using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst;

public class Product
{
    [Required, MaxLength(30), RegularExpression("^[A-Z][a-z0-9]+$")]
    public string Name { get; set; }
    
    [Key]
    public int Id { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; } // Нужен для того чтобы обращаться к категории удобно

    [Required, DefaultValue(99.99), Range(0, 10_000_000)]
    public float Price { get; set; }
}


